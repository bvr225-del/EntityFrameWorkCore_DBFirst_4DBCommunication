using EntityFrameWorkCore_DBFirst_4DBCommunication.NorthWind_DbModels;
using EntityFrameWorkCore_DBFirst_4DBCommunication.RestaurantModels;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetRestaurants();
        Task<Restaurant> GetRestaurantById(int Id);
        Task<int> AddRestaurants(Restaurant resdetail);
        Task<bool> DeleteRestaurantById(int Id);
        Task<bool> UpdateRestaurant(Restaurant resdetail);


    }
}
