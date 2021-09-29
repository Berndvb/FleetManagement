using FleetManagement.Framework.Models.Enums;
using System;

namespace FleetManagement.Framework.Models.Dtos.ShowDtos
{
    public class AppealInfoDto
    {
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }

        public AppealTypes AppealType { get; set; }

        public DateTime? FirstDatePlanning { get; set; }

        public DateTime? SecondDatePlanning { get; set; }

        public AppealStatus Status { get; set; }

        public VehicleOverviewDto Vehicle { get; set; }

        public string Message { get; set; }

        public AppealInfoDto(
            int id,
            DateTime creationDate,
            AppealTypes appealType,
            DateTime firstDatePlanning,
            DateTime? secondDatePlanning,
            AppealStatus status,
            VehicleOverviewDto vehicle,
            string message)
        {
            Id = id;
            CreationDate = creationDate;
            AppealType = appealType;
            FirstDatePlanning = firstDatePlanning;
            SecondDatePlanning = secondDatePlanning;
            Status = status;
            Vehicle = vehicle;
            Message = message;
        }

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
}
