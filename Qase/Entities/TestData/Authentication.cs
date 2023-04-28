using Qase.Entities.Models;

namespace Qase.Entities.TestData;

public class Authentication
{
    public UserModel User()
    {
        return new UserModel
        {
            Email = "sergey.zrch@gmail.com",
            Password = "Deadspace456,"
        };
    }
    
    public UserModel FakeUser()
    {
        return new UserModel
        {
            Email = "govere123@gmail.com",
            Password = "Deadsaaaa21"
        };
    }
}