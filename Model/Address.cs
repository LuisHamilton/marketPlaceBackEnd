using System;
using System.Collections.Generic;
using Interfaces;
using DAO;
using DTO;

namespace Model;
public class Address : IValidateDataObject, IDataController<AddressDTO, Address>
{
    //Atributos
    private String street;
    private String city;    
    private String state;   
    private String country;
    private String postal_code;
    public List<AddressDTO> addressDTO = new List<AddressDTO>();

    public Address (String street, String city, String state, String country, String postal_code)
    {
        this.street=street;
        this.city=city;
        this.state=state;
        this.country=country;
        this.postal_code=postal_code;
    }
 
    //Métodos

    public static Address convertDTOToModel(AddressDTO obj)
    {
        return new Address(obj.street, obj.city, obj.state, obj.country, obj.postal_code);
    }
    public void delete(AddressDTO obj){}
    public int save()
    {
        var id = 0;

        using(var context = new DaoContext())
        {
            var address = new DAO.Address{
                street = this.street,
                city = this.city,
                state = this.state,
                country = this.country,
                postal_code = this.postal_code
            };
            context.Address.Add(address);
            context.SaveChanges();
            id = address.id;
        }
        return id;
    }
    public void update(AddressDTO obj){}
    public AddressDTO findById(int id)
    {
        return new AddressDTO();
    }
    public List<AddressDTO> getAll()
    {
        return this.addressDTO;
    }
    public AddressDTO convertModelToDTO()
    {
        var addressDTO = new AddressDTO();
        addressDTO.street = this.street;
        addressDTO.city = this.city;
        addressDTO.state = this.state;
        addressDTO.country = this.country;
        addressDTO.postal_code = this.postal_code;

        return addressDTO;
    }
    public Boolean validateObject()
    {
        if(this.getStreet() == null) { return false; }
        if(this.getCity() == null) { return false; }
        if(this.getState() == null) { return false; }    
        if(this.getCountry() == null) { return false; }
        if(this.getPostalCode() == null) { return false; }
        return true;
    }
    //GETs e SETs
    public String getStreet(){ return this.street; }
    public void setStreet(String street) { this.street = street; }

    public String getCity(){return this.city;}
    public void setCity(String city){this.city=city;}
    public String getState(){return this.state;}
    public void setState(String state){this.state=state;}

    public String getCountry(){return this.country;}
    public void setCountry(String country){this.country=country;}

    public String getPostalCode(){return this.postal_code;}
    public void setPostalCode(String postal_code){this.postal_code=postal_code;}

}
