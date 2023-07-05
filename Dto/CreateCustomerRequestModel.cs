namespace CLHBankApp.Dto
{
    public class CreateCustomerRequestModel : CreateUserRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Pin { get; set; }
        public IFormFile FormFile { get; set; }
    }
}