using CityManagerApi3_22_05.Entities;

namespace CityManagerApi3_22_05.Dtos
{
    public class CityDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
