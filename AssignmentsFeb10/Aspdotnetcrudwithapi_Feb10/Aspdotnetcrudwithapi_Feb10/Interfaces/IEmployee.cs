using Aspdotnetcrudwithapi_Feb10.Models;

namespace Aspdotnetcrudwithapi_Feb10.Interfaces
{
    public interface IEmployee
    {
        //create definition of create 
        List<TEmployee> Create(TEmployee employee); 
    }
}
