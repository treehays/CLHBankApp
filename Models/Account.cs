
namespace CLHBankApp.Models;
public class Account : BaseClass
{
    public string AccountNumber {get;set;}
    public string Pin {get;set;}
    public decimal Balance {get;set;}   
    public int CustomerId {get;set;}
    public Customer Customer{get;set;}
    public IList<Transaction> Transactions {get;set;} = new List<Transaction>();

}
