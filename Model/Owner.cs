using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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
    public Owner(){}
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
            var addressDAO = new DAO.Address
            {
                street = this.address.getStreet(),
                city = this.address.getCity(),
                state = this.address.getState(),
                country = this.address.getCountry(),
                postal_code = this.address.getPostalCode()
            };
            var ownerDAO = new DAO.Owner
            {
                name = this.name,
                date_of_birth = this.date_of_birth,
                document = this.document,
                email = this.email,
                phone = this.phone,
                passwd = this.passwd,
                login = this.login,
                address = addressDAO
            };
            context.Owner.Add(ownerDAO);
            context.Entry(ownerDAO.address).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.SaveChanges();
            id = ownerDAO.id;
        }
        return id;
    }
    public void update(OwnerDTO obj){}
    public OwnerDTO findById(int id)
    {
        return new OwnerDTO();
    }
    public static OwnerDTO getById(int Id)
    {
        using(var context = new DaoContext())
        {
            OwnerDTO ownerDTO = new OwnerDTO();
            var ownerDAO = context.Owner.Include(c=>c.address).Where(c => c.id == Id).Single();
            ownerDTO.name = ownerDAO.name;
            ownerDTO.date_of_birth = ownerDAO.date_of_birth;
            ownerDTO.document = ownerDAO.document;
            ownerDTO.email = ownerDAO.email;
            ownerDTO.phone = ownerDAO.phone;
            ownerDTO.login = ownerDAO.login;
            ownerDTO.passwd = ownerDAO.passwd;
            ownerDTO.address = new AddressDTO();
            ownerDTO.address.street = ownerDAO.address.street;
            ownerDTO.address.city = ownerDAO.address.city;
            ownerDTO.address.state = ownerDAO.address.state;
            ownerDTO.address.country = ownerDAO.address.country;
            ownerDTO.address.postal_code = ownerDAO.address.postal_code;
            return ownerDTO;
        }
    }
    public static int findId(OwnerDTO owner)
    {
        using(var context = new DaoContext())
        {
            var ownerID = context.Owner.Where(c=>c.login == owner.login && c.passwd == owner.passwd).Single();
            return ownerID.id;
        }
    }
    public static OwnerDTO getByLogin(OwnerDTO login)
    {
        OwnerDTO ownerDTO = new OwnerDTO();
        using(var context = new DaoContext())
        {
            var ownerDAO = context.Owner.Where(c => c.login == login.login && c.passwd == login.passwd).Single();
            ownerDTO.name = ownerDAO.name;
            ownerDTO.date_of_birth = ownerDAO.date_of_birth;
            ownerDTO.document = ownerDAO.document;
            ownerDTO.email = ownerDAO.email;
            ownerDTO.phone = ownerDAO.phone;
            ownerDTO.login = ownerDAO.login;
            ownerDTO.passwd = ownerDAO.passwd;
            return ownerDTO;
        }
    }
    public static object findByDocument(String doc)
    {
        using(var context = new DaoContext())
        {
            var ownerInstance = context.Owner.Include(c=>c.address).Where(c => c.document == doc).Single();
            return ownerInstance;
        }
    }
    public static int findToStore(String doc)
    {
        using(var context = new DaoContext())
        {
            var ownerInstance = context.Owner.Include(c=>c.address).Where(c => c.document == doc).Single();
            return ownerInstance.id;
        }
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