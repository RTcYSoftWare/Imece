using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos
{
    public class PlantationCreateOrUpdateDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public double Altitude { get; set; }
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public int GrowingAreaId { get; set; }
        public DateTime SowingPlantingAt { get; set; }
        public DateTime HarvestAt { get; set; }
        public int Decare { get; set; }
        public int? SoilTypeId { get; set; }
        public int? IrrigationTypeId { get; set; }
    }
}
