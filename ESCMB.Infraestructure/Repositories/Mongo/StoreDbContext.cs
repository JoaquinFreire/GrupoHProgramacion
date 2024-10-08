﻿using Core.Infraestructure.Repositories.MongoDb;
using ESCMB.Domain.Entities;
using ESCMB.Infraestructure.Repositories.Mongo.Maps;
using MongoDB.Driver;

namespace ESCMB.Infraestructure.Repositories.Mongo
{
    /// <summary>
    /// Contexto de almacenamiento en base de datos. Aca se definen los nombres de 
    /// las colecciones, y los mapeos entre los objetos
    /// </summary>
    internal class StoreDbContext : DbContext
    {
        public StoreDbContext(string connectionString) : base(connectionString)
        {
            MapTypes();
        }

        public override IMongoCollection<T> GetCollection<T>()
        {
            if (typeof(T) == typeof(DummyEntity))
                return Database.GetCollection<T>(DummyEntityMap.GetCollectionName());
            return null;
        }

        private static void MapTypes()
        {
            DummyEntityMap.Configure();
        }
    }
}
