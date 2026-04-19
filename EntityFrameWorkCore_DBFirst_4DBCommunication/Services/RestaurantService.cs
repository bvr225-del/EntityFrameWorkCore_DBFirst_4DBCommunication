using EntityFrameWorkCore_DBFirst_4DBCommunication.Dtos;
using EntityFrameWorkCore_DBFirst_4DBCommunication.Interfaces;
using EntityFrameWorkCore_DBFirst_4DBCommunication.MidlandModels;
using EntityFrameWorkCore_DBFirst_4DBCommunication.NorthWind_DbModels;
using EntityFrameWorkCore_DBFirst_4DBCommunication.Repositories;
using EntityFrameWorkCore_DBFirst_4DBCommunication.RestaurantModels;

namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository=restaurantRepository;
        }
        public async Task<int> AddRestaurants(RestaurantDto resdetail)
        {
            Restaurant res = new Restaurant();
            res.Id = resdetail.Id;
            res.RestaurantName = resdetail.RestaurantName;
            res.RestaurantLocation = resdetail.RestaurantLocation;
            res.CreationDate = resdetail.CreationDate;
            var result = await _restaurantRepository.AddRestaurants(res);
            return 1;

        }

        public async  Task<bool> DeleteRestaurantById(int Id)
        {
            await _restaurantRepository.DeleteRestaurantById(Id);
            return true;

        }

        public async Task<RestaurantDto> GetRestaurantById(int Id)
        {
            var res = await _restaurantRepository.GetRestaurantById(Id);
            RestaurantDto resdto = new RestaurantDto();
            resdto.Id = res.Id;
            resdto.RestaurantName = res.RestaurantName;
            resdto.RestaurantLocation = res.RestaurantLocation;
            resdto.CreationDate = res.CreationDate;
            return resdto;

        }

        public async Task<List<RestaurantDto>> GetRestaurants()
        {
            List<RestaurantDto> listresdto = new List<RestaurantDto>();
            var res = await _restaurantRepository.GetRestaurants();
            foreach (Restaurant restaurant in res)
            {
                RestaurantDto resDto = new RestaurantDto();
                resDto.Id = restaurant.Id;
                resDto.RestaurantName = restaurant.RestaurantName;
                resDto.RestaurantLocation = restaurant.RestaurantLocation;
                resDto.CreationDate=restaurant.CreationDate;
                listresdto.Add(resDto);//Add the orders to list here

            }
            return listresdto;

        }

        public async Task<bool> UpdateRestaurant(RestaurantDto resdetail)
        {
            Restaurant obj = new Restaurant();
            obj.Id = resdetail.Id;
            obj.RestaurantName = resdetail.RestaurantName;
            obj.RestaurantLocation = resdetail.RestaurantLocation;
            obj.CreationDate = resdetail.CreationDate;
            await _restaurantRepository.UpdateRestaurant(obj);
            return true;


        }
    }
}
