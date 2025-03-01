using System;
using emregayrımenkul.Models;

namespace emregayrımenkul.Repository;

public class CityService : ICityService

{
    private readonly ICityRepository _cityRepository;

    public CityService(ICityRepository cityRepository)
    {
            _cityRepository = cityRepository;
    }

    public async Task<ICollection<City>> GetAllCitiesAsync()
    {
        return await _cityRepository.GetAllCitiesAsync();// tüm şehirleri ve ilçeleri getirdim

    }

    public async Task<City> GetCityByIdAsync(int id)
    {
        var city = await _cityRepository.GetcitiesByIdAsync(id);

        if(city == null){
            
            throw new  KeyNotFoundException("Şehir bulunamadı");
        }
        return city;
        
    }
     public async Task<bool> AddCity(City city)
    {
        if(city == null){
            return false;
        }
        await _cityRepository.AddCityAsync(city);
        return true;
    }

    public async Task<bool> DeleteCity(int id)
    {
        var city = await _cityRepository.GetcitiesByIdAsync(id);
        if(city == null){
            return false;
        }
        await _cityRepository.DeleteCityAsync(id);
        return true;
    }

    public async Task<bool> UpdateCity(City city)
    {
        if(city == null){
            return false;
        }

        await _cityRepository.UpdateCityAsync(city);
        return true;
    }
}
