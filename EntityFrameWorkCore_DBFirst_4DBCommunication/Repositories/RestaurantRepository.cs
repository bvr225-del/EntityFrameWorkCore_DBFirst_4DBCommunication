using EntityFrameWorkCore_DBFirst_4DBCommunication.hotelmanagementModels;
using EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_DBFirst_4DBCommunication.RestaurantModels;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly RestaurantDbContext _restaurantDbContext;
        public RestaurantRepository(RestaurantDbContext restaurantDbContext)
        {
            _restaurantDbContext=restaurantDbContext;
        }
        public async Task<int> AddRestaurants(Restaurant resdetail)
        {
            await _restaurantDbContext.Restaurants.AddAsync(resdetail);
            _restaurantDbContext.SaveChanges();
            return 1;

        }

        public async Task<bool> DeleteRestaurantById(int Id)
        {
            var result = await _restaurantDbContext.Restaurants.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if (result != null)
            {
                _restaurantDbContext.Restaurants.Remove(result);
                _restaurantDbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<Restaurant> GetRestaurantById(int Id)
        {
            //To get the one record use below linq query
            var result = await _restaurantDbContext.Restaurants.Where(b => b.Id == Id).FirstOrDefaultAsync();
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }

        }

        public async Task<List<Restaurant>> GetRestaurants()
        {
            var result = await _restaurantDbContext.Restaurants.ToListAsync();
            if (result.Count == 0)
            {
                return null;
            }
            else
            {
                return result;
            }

        }

        public async Task<bool> UpdateRestaurant(Restaurant resdetail)
        {
            //this is one way of update the data
            //  _restaurantDbContext.Restaurants.Update(resdetail);

            //second way of update the data(Realtime use this way)
            var resResult = await _restaurantDbContext.Restaurants.Where(b => b.Id == resdetail.Id).FirstOrDefaultAsync();
            resResult.Id = resdetail.Id;
            resResult.RestaurantName = resdetail.RestaurantName;
            resResult.RestaurantLocation = resdetail.RestaurantLocation;
            resResult.CreationDate = resdetail.CreationDate;

            _restaurantDbContext.Restaurants.Update(resResult);
            await _restaurantDbContext.SaveChangesAsync();
            return true;

        }
    }
}
