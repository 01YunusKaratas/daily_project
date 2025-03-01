using System;
using emregayrımenkul.Models;
using Microsoft.EntityFrameworkCore;
namespace emregayrımenkul.Repository;

public class AdvertService : IAdvertService  //implement ediyoruz yazdıgımız interfacei
{
    //damima constructurı ekle unutma

    private readonly IAdvertRepository _advertRepository; // servisi de repoya baglıyoruz ordan alıyoruz bilgileri
    public AdvertService(IAdvertRepository advertRepository)
    {
        _advertRepository = advertRepository;
    }


    //ekleme methodunu repodan çağırdık kullandık
    public async Task<bool> AddAdvertAsync(Advert advert, IFormFile imageFile)
    {
        if( advert == null){

            return false;

        }
        await _advertRepository.AddAdvertAsync(advert,imageFile);
        return true;
    }   

    public async Task<Advert> GetAdvertByIdAsync(int id)
    {
        var advert = await _advertRepository.GetAdvertByIdAsync(id);//  git bak dbye

        if( advert == null){
            
            throw new KeyNotFoundException("Ürün bulunamadı");
        }

        return advert; //ilanı getir

    }

    public async Task<ICollection<Advert>> GetAdvertListAsync()
    {
        return await _advertRepository.GetAllAdvertAsync(); //tüm listeyi getir
    }

    public async Task<bool> RemoveAdvertAsync(int id)
    {
        var advert  =await _advertRepository.GetAdvertByIdAsync(id);
        if(advert == null){

            return false;
        }

        await _advertRepository.DeleteAdvertAsync(id);
        return true;
    }

   public async Task<bool> UpdateAdvertAsync(Advert advert, IFormFile newImageFile)
    {
        if (advert == null) return false;

        await _advertRepository.UpdateAdvertAsync(advert, newImageFile);
        return true;
    }
}
