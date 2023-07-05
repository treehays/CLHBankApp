namespace CLHBankApp.Models
{
    public class Address : BaseClass
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}