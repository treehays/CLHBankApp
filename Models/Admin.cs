
namespace CLHBankApp.Models;
public class Admin : BaseUser
{
    public int UserId { get; set; }
    public User User{ get; set; }
}
