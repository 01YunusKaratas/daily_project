using System;
using emregayrımenkul.Data;
using emregayrımenkul.Models;
using Microsoft.EntityFrameworkCore; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace emregayrımenkul.Repository;

public interface IAdvertRepository
{

    Task<ICollection<Advert>> GetAllAdvertAsync(); //tüm ilanlar
    Task<Advert> GetAdvertByIdAsync(int id);// id ye göre ilan
    Task AddAdvertAsync(Advert advert,IFormFile imageFile); //ilan ekle
    Task DeleteAdvertAsync(int id); //ilan sil
    Task UpdateAdvertAsync(Advert advert,IFormFile newImageFile);//ilan güncelle

}
