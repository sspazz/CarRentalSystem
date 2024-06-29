namespace CarRentalSystem.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public CarType Type { get; set; }
    }

    public enum CarType
    {
        Premium,
        SUV,
        Small
    }
}
