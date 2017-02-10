using System.Collections.Generic;

namespace Addresses.Objects
{
  public class Address {
    private string _name;
    private string _street;
    private string _city;
    private string _state;
    private int _zip;
    private int _id;
    private static List<Address> _instances = new List<Address>{};

    public Address(string addressName)
    {
      _name = addressName;
      _street = addressStreet;
      _city = addressCity;
      _state = addressState;
      _zip = addressZip;
      _instances.Add(this);
      _id = instances.Count;
    }
    

  }
}
