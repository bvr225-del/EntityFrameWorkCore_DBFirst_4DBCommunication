namespace EntityFrameWorkCore_DBFirst_4DBCommunication.Dtos
{
    public class RestaurantDto
    {
        public int Id { get; set; }

        public string? RestaurantName { get; set; }

        public string? RestaurantLocation { get; set; }

        public DateTime? CreationDate { get; set; }

    }
}
