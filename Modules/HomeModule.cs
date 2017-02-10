using Nancy;
using Addresses.Objects;
using System.Collections.Generic;

namespace Addresses
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get ["/"] = _ => {
        List<Address> allAddresses = Address.GetAll();
        return View["index.cshtml", allAddresses];
      };



    }
  }
}
