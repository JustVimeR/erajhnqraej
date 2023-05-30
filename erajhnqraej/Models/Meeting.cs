namespace erajhnqraej.Models
{
    public class Meeting
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int ID { get; set; }
        public DateTime Meetings { get; set; }
        public int CarId { get; set; }
        public virtual Car Car { get; set; }
    }
}
