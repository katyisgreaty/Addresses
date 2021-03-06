using Nancy;
using Addresses.Objects;
using System;
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
        Address newAddress = new Address(Request.Form["new-name"], Request.Form["new-street"], Request.Form["new-city"], Request.Form["new-state"], Request.Form["new-zip"]);
        List<Address> allAddresses = Address.GetAll();
        return View["index.cshtml", allAddresses];
      };

      Post["/addresses/cleared"] = _ => {
        Address.ClearAll();
        return View["addresses_cleared.cshtml"];
      };

      Get["/search_by_name"] = _ => {
        return View["search_by_name.cshtml"];
      };

      Post["/search_results"] = _ => {
        Address foundAddress = Address.SearchByName(Request.Form["search-name"]);
        return View["search_results.cshtml", foundAddress];
      };
    }
  }
}
