namespace CarRentalSystem.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentalDate { get; set; }
        public int RentalDays { get; set; }
        public int ExtraDays { get; set; }
        public decimal Price { get; set; }
    }
}
