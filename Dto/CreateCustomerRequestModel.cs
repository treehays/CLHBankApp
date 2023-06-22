namespace CLHBankApp.Dto
{
    public class CreateCustomerRequestModel
    {
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public IFormFile FormFile { get; set; }
    }
}