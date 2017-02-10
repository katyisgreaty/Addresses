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
        var allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };

      Get["/contacts/new"] = _ => {
        return View["new_contact.cshtml"];
      };

      Get["/contacts/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var selectedContact = Contact.Find(parameters.id);
        var contactAddresses = selectedContact.GetAddresses();
        model.Add("contact", selectedContact);
        model.Add("addresses", contactAddresses);
        return View["contact.cshtml", model];
      };

      Post["/"] = _ => {
        var newContact = new Contact(Request.Form["contact-name"]);
        var allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };

      Post["/contacts/cleared"] = _ => {
        Contact.ClearAll();
        return View["contacts_cleared.cshtml"];
      };



    }
  }
}
