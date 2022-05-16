using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantAPI.Entities;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any()) //check if table is empty
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "Kentucky Fried Chicken",
                    ContactNumber = "123123123",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Price = 10.30M,
                            Description = "Hot Chicken",
                        },

                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 5.30M,
                            Description = "Hot Nuggets",
                        },
                    },
                    Address = new Address()
                    {
                        City = "Kraków",
                        Street = "Długa 5",
                        PostalCode = "30-001"
                    }
                },

                new Restaurant()
                {
                    Name = "McDonald",
                    Category = "Fast Food",
                    Description = "Clown with burgers",
                    ContactNumber = "123123124",
                    ContactEmail = "contact@mcd.com",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "BigMac",
                            Price = 10.00M,
                            Description = "Hot BigMac",
                        },

                        new Dish()
                        {
                            Name = "McRoyal",
                            Price = 12.30M,
                            Description = "Hot McRoyal",
                        },
                    },
                    Address = new Address()
                    {
                        City = "Warszawa",
                        Street = "Długa 5",
                        PostalCode = "00-001"
                    }
                }
            };

            return restaurants;
        }
    }
}
