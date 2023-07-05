namespace CLHBankApp.Dto
{
    public class UpdateCustomerRequestModel
    {
        public IFormFile ProfilePics { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
    }
}