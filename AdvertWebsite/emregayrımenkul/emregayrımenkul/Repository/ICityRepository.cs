using System;
using emregayrımenkul.Models;

namespace emregayrımenkul.Repository;

public interface ICityRepository
{
    Task<ICollection<City>> GetAllCitiesAsync(); //tüm şehirleri getir

    Task<City> GetcitiesByIdAsync(int id); // idye göre getir şehirleri

    Task AddCityAsync(City city);
    Task DeleteCityAsync(int id);
    Task UpdateCityAsync(City city);
}
