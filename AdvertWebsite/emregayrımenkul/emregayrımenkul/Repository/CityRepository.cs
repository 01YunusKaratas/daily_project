using System;
using System.Data.Entity;
using emregayrımenkul.Data;
using emregayrımenkul.Models;

namespace emregayrımenkul.Repository;

public class CityRepository : ICityRepository
{
    private readonly ApplicationDbContext _context;
    public CityRepository(ApplicationDbContext context)
    {
        _context=context;
    }
    public async Task AddCityAsync(City city)
    {
        await _context.City.AddAsync(city); //burada şehirlere ekledik
        await _context.SaveChangesAsync();

    }
    
    //burada birtane dönderiyoruz o yüzden ICollection kullanmamıza gerek yok
    public async Task<City>GetcitiesByIdAsync(int id)
    {
       return await _context.City.Include(y=>y.Districts).FirstOrDefaultAsync(y=>y.Id == id);

        
    }

    public async Task DeleteCityAsync(int id)
    {
        var city = await _context.City.FindAsync(id);

        if (city != null){

            _context.City.Remove(city);
            await _context.SaveChangesAsync();

        }

    }

    public async Task<ICollection<City>> GetAllCitiesAsync()
    {
        return await _context.City.Include(y=>y.Districts).ToListAsync();
    }

    public async Task UpdateCityAsync(City city)
    {
        _context.City.Update(city);
        await _context.SaveChangesAsync();
    }
}
