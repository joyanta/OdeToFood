using OdeToFood.Entities;
using System.Collections.Generic;
using System.Linq;
using System;

namespace OdeToFood.Services
{
    public interface IRestaurantData
    {
        int Commit();
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        void Add(Restaurant newRestaurant);
    }

    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDBContext _context;

        public SqlRestaurantData(OdeToFoodDBContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Add(Restaurant newRestaurant)
        {
            _context.Add(newRestaurant);
        }

        public Restaurant Get(int id)
        {
            return _context.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _context.Restaurants.ToList();
        }
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        static List<Restaurant> _restaurants;
        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Nandos" },
                new Restaurant { Id = 2, Name = "Wasabi" },
                new Restaurant { Id = 3, Name = "Mc Donalds" }
            };
        }

        public int Commit()
        {
            return 0;
        }

        public void Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }
    }
}
