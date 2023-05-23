using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Plantation : BaseEntity
    {
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
        public int UserId { get; set; }
        public string Parcel { get; set; }
        public string Ada { get; set; }

        public Product Product { get; set; }
        public ProductType ProductType { get; set; }
        public GrowingArea GrowingArea { get; set; }
        public SoilType SoilType { get; set; }
        public IrrigationType IrrigationType { get; set; }
    }
}
