namespace CLHBankApp.Dto
{
    public class CreateAdminRequestModel : CreateUserRequestModel
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string PhoneNumber {get;set;}
        public string ImageReference {get;set;} 
    }
}

