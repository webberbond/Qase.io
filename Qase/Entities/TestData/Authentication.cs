using Qase.Entities.Models;

namespace Qase.Entities.TestData;

public abstract class Authentication
{
    public static UserModel User()
    {
        return new UserModel
        {
            Email = "sergey.zrch@gmail.com",
            Password = "Deadspace456,"
        };
    }
    
    public static UserModel FakeUser()
    {
        return new UserModel
        {
            Email = "govere123@gmail.com",
            Password = "Deadsaaaa21"
        };
    }
}