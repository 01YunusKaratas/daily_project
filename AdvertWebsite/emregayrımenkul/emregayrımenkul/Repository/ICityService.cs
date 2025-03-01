using System;
using emregayrımenkul.Models;

namespace emregayrımenkul.Repository;

public interface ICityService
{
    Task<ICollection<City>> GetAllCitiesAsync();
    Task<City> GetCityByIdAsync(int id);
    Task<bool> AddCity(City city);
    Task<bool> DeleteCity(int id);
    Task<bool> UpdateCity(City city);
}
