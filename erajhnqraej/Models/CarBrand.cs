namespace erajhnqraej.Models
{
        public class CarBrand
        {
            public int ID { get; set; }
            public string Brand { get; set; }
            public virtual ICollection<Car> Cars { get; set; }
        } 
}
