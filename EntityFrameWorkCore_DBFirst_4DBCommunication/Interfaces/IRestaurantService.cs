using EntityFrameWorkCore_DBFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_DBFirst_4DBCommunication.RestaurantModels;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces
{
    public interface IRestaurantService
    {
        Task<List<RestaurantDto>> GetRestaurants();
        Task<RestaurantDto> GetRestaurantById(int Id);
        Task<int> AddRestaurants(RestaurantDto resdetail);
        Task<bool> DeleteRestaurantById(int Id);
        Task<bool> UpdateRestaurant(RestaurantDto resdetail);

    }
}
