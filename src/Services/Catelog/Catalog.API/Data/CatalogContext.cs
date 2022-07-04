﻿using Catalog.API.Data.Interfaces;
using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {

        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString")); //server name
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName")); //database name
            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName")); //Collections name
            CatalogContextSeed.SeedData(Products);

        }
        public IMongoCollection<Product> Products {get;}
    }
}
