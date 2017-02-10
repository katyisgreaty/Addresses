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

    public Address(string name, string street, string city, string state, int zip)
    {
      _name = name;
      _street = street;
      _city = city;
      _state = state;
      _zip = zip;
      _instances.Add(this);
      _id = _instances.Count;
    }
//Getters and Setters
    public string GetName()
    {
      return _name;
    }

    public void SetName(string newName)
    {
      _name = newName;
    }

    public string GetStreet()
    {
      return _street;
    }

    public void SetStreet(string newStreet)
    {
      _street = newStreet;
    }

    public string GetCity()
    {
      return _city;
    }

    public void SetCity(string newCity)
    {
      _city = newCity;
    }

    public string GetState()
    {
      return _state;
    }

    public void SetState(string newState)
    {
      _state = newState;
    }

    public int GetZip()
    {
      return _zip;
    }

    public void SetZip(int newZip)
    {
      _zip = newZip;
    }

    public int GetId()
    {
      return _id;
    }
//Other Methods
    public static List<Address> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Address Find(int searchId)
    {
      return _instances[searchId-1];
    }

  }
}
