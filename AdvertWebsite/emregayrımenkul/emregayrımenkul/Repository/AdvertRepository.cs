using emregayrımenkul.Data;
using emregayrımenkul.Models;
using Microsoft.EntityFrameworkCore;  
using System.Collections.Generic;
using System.Threading.Tasks;


namespace emregayrımenkul.Repository;

public class AdvertRepository :IAdvertRepository  // burada extends ettik yazdıgımız interface göre methodları doldurduk
{
    private readonly ApplicationDbContext _context; //burada yani repoyu db ye bagladık ve işlemleri yapcaz

    public AdvertRepository(ApplicationDbContext context) //burada constructora aldık
    {
        _context=context;
    }

    //Repoda direk database ile ilişkili kodlar yazıyoz
    public async Task AddAdvertAsync(Advert advert,IFormFile imageFile)
    {
            if (imageFile != null && imageFile.Length > 0)
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", imageFile.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(stream);
            }
            advert.UrlImage = $"/images/{imageFile.FileName}";
        }

        await _context.Advert.AddAsync(advert);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAdvertAsync(int id)
    {
        var advert = await _context.Advert.FindAsync(id); 

        if(advert != null){

           _context.Advert.Remove(advert);
          await _context.SaveChangesAsync();
        } 
    }

    //git advertdetailsida al gelilk idli olanı getir
    public async Task<Advert> GetAdvertByIdAsync(int id)
    {
        return await _context.Advert.Include(y=>y.AdvertDetails).FirstOrDefaultAsync(y=>y.Id == id);
    }


    public async Task<ICollection<Advert>> GetAllAdvertAsync()
    {
        return await _context.Advert.ToListAsync();
    }

    public async Task UpdateAdvertAsync(Advert advert, IFormFile newImageFile)
{
    var existingAdvert = await _context.Advert.FindAsync(advert.Id);
    if (existingAdvert != null)
    {
        if (newImageFile != null && newImageFile.Length > 0)
        {
            var newFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", newImageFile.FileName);
            
            // Yeni resmi kaydet
            using (var stream = new FileStream(newFilePath, FileMode.Create))
            {
                await newImageFile.CopyToAsync(stream);
            }

            // Eski resmi sil
            if (!string.IsNullOrEmpty(existingAdvert.UrlImage))
            {
                var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", existingAdvert.UrlImage.TrimStart('/'));
                if (System.IO.File.Exists(oldFilePath))
                {
                    System.IO.File.Delete(oldFilePath);
                }
            }

            // Yeni resim yolunu kaydet
            existingAdvert.UrlImage = $"/images/{newImageFile.FileName}";
        }

        existingAdvert.AdvertTitle = advert.AdvertTitle;
        existingAdvert.Explain = advert.Explain;
        existingAdvert.Cost = advert.Cost;

        _context.Advert.Update(existingAdvert);
        await _context.SaveChangesAsync();
    }
}

}
