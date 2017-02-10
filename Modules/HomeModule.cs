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
        var newContact = new Contact(Request.Form["contact-name"], Request.Form["contact-phone"]);
        var allContacts = Contact.GetAll();
        return View["index.cshtml", allContacts];
      };

      Post["/contacts/cleared"] = _ => {
        Contact.Clear();
        return View["contacts_cleared.cshtml"];
      };

      Get["/contacts/{id}/addresses/new"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Contact selectedContact = Contact.Find(parameters.id);
        List<Address> allAddresses = selectedContact.GetAddresses();
        model.Add("contact" ,selectedContact);
        model.Add("addresses", allAddresses);
        return View["new_contact_address.cshtml", model];
      };

      Post["/addresses"] = _ => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Contact selectedContact = Contact.Find(Request.Form["contact-id"]);
        List<Address> contactAddresses = selectedContact.GetAddresses();
        string addressStreet = Request.Form["address-street"];
        string addressCity = Request.Form["address-city"];
        string addressState = Request.Form["address-state"];
        int addressZip = Request.Form["address-zip"];
        Address newAddress = new Address(addressStreet, addressCity, addressState, addressZip);
        contactAddresses.Add(newAddress);
        model.Add("addresses", contactAddresses);
        model.Add("contact", selectedContact);
        return View["contact.cshtml", model];
      };



    }
  }
}
