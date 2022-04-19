using System;
using System.Collections.Generic;
using Interfaces;
using DAO;
using DTO;

namespace Model;
public class Owner : Person, IValidateDataObject, IDataController<OwnerDTO, Owner>
{
    private Guid uuid = Guid.NewGuid();
    public List<OwnerDTO> ownerDTO = new List<OwnerDTO>();
    //Método para pegar a instância
    private static Owner instance;
    private Owner(Address address):base(address){}
    public static Owner getInstance(Address address)
    {
        if (instance == null)
        {
            instance = new Owner(address);
        }
        return instance;
    }
    public Boolean validateObject()
    {
        if (this.getName() == null) { return false; }
        if (this.getDateOfBirth() == null) { return false; }
        if (this.getDocument() == null) { return false; }
        if (this.getEmail() == null) { return false; }
        if (this.getPhone() == null) { return false; }
        if (this.getLogin() == null) { return false; }
        if (this.getPasswd() == null) {return false; }
        if (this.getAddress() == null) { return false; }
        return true;
    }
    public static Owner convertDTOToModel(OwnerDTO obj)
    {
        var owner = new Owner(Address.convertDTOToModel(obj.address));

        owner.setName(obj.name);
        owner.setDateOfBirth(obj.date_of_birth);
        owner.setDocument(obj.document);
        owner.setEmail(obj.email);
        owner.setPhone(obj.phone);
        owner.setLogin(obj.login);
        owner.setPasswd(obj.passwd);
        return owner;
    }
    public void delete(OwnerDTO obj){}
    public int save()
    {
        var id = 0;
        using(var context = new DaoContext())
        {
            var address = new DAO.Address
            {
                street = this.address.getStreet(),
                city = this.address.getCity(),
                state = this.address.getState(),
                country = this.address.getCountry(),
                postal_code = this.address.getPostalCode()
            };
            var owner = new DAO.Owner
            {
                name = this.name,
                date_of_birth = this.date_of_birth,
                document = this.document,
                email = this.email,
                phone = this.phone,
                passwd = this.passwd,
                login = this.login
            };
            context.Owner.Add(owner);
            context.SaveChanges();
            id = owner.id;
        }
        return id;
    }
    public void update(OwnerDTO obj){}
    public OwnerDTO findById(int id)
    {
        return new OwnerDTO();
    }
    public List<OwnerDTO> getAll()
    {
        return this.ownerDTO;
    }
    public OwnerDTO convertModelToDTO()
    {
        var ownerDTO = new OwnerDTO();

        ownerDTO.name = this.name;
        ownerDTO.date_of_birth = this.date_of_birth;
        ownerDTO.document = this.document;
        ownerDTO.email = this.email;
        ownerDTO.phone = this.phone;
        ownerDTO.login = this.login;
        ownerDTO.passwd = this.passwd;
        ownerDTO.address = this.address.convertModelToDTO();
        return ownerDTO;
    }
}