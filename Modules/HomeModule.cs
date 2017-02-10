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
      Get["/addresses/new"] = _ => {
        return View["new_address.cshtml"];
      };
      Get["/addresses/{id}"] = parameters => {
        Address address = Address.Find(parameters.id);
        return View["address.cshtml", address];
      };
      Post["/"] = _ => {
        Address newAddress = new Address(Request.Form["new-name"]);
        List<Address> allAddresses = Address.GetAll();
        return View["index.cshtml", allAddresses];
      };


    }
  }
}
