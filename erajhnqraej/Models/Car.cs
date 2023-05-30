using System.ComponentModel.DataAnnotations;

namespace erajhnqraej.Models
{
    public class Car
    {
        [Key]
        public int ID { get; set; }
        public decimal Price { get; set; }
        public int CarYear { get; set; }
        public decimal FuelConsumption { get; set; }
        public decimal CarRun { get; set; }   
        public string CarPoint { get; set; }
        public int BrandId {get; set; }
        public string CarModel { get; set; }
        public virtual CarBrand CarBrand { get; set; }
        public virtual ICollection<Meeting> Meetings { get; set; }
    }
}
