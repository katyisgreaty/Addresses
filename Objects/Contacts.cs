using System.Collections.Generic;

namespace Addresses.Objects
{
  public class Contact
  {
    private static List<Contact> _instances = new List<Contact> {};
    private string _name;
    private string _phone;
    private int _id;
    private List<Contact> _addresses;

    public Contact(string contactName, string contactPhone)
    {
      _name = contactName;
      _phone = contactPhone;
      _instances.Add(this);
      _id = _instances.Count;
      _addresses = new List<Address>{};
    }
    public string GetName()
    {
      return _name;
    }
    public string GetPhone()
    {
      return _phone;
    }
    public int GetId()
    {
      return _id;
    }
    public List<Address> GetAddresses()
    {
      return _addresses;
    }
    public void AddAddress(Address address)
    {
      _addresses.Add(address);
    }
    public static List<Contact> GetAll()
    {
      return _instances;
    }
    public static void Clear()
    {
      _instances.Clear();
    }
    public static Contact Find(int searchId)
    {
      return _instances[searchId - 1];
    }

  }
}
