namespace JuniperJunctionDistillery.Models
{
    public class Bookings
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime Date { get; set; }
        public string ExperienceType { get; set; } // Gin Tasting or Gin Making
        public string PreferredTime { get; set; }
    }
}
