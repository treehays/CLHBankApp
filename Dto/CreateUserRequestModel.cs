namespace CLHBankApp.Dto
{
    public class CreateUserRequestModel
    {
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
    }
}