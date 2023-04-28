using RestSharp;

namespace Qase.Services;

public abstract class BaseService
{
    protected readonly RestClient RestClient;

    protected BaseService()
    {
        RestClient = new RestClient();
        var token = "88406d102e3323ae5f5e585db3eba08335d58c859d897221b15088ccba9626c1";
        
        RestClient.AddDefaultHeader("token", token);
    }
}