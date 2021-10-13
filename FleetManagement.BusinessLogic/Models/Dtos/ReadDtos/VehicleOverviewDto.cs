namespace FleetManagement.BLL.Models.Dtos.ReadDtos
{
    public class VehicleOverviewDto
    {
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public VehicleOverviewDto(
            int id,
            string brand,
            string model)
        {
            Id = id;
            Brand = brand;
            Model = model;
        }
    }
}
