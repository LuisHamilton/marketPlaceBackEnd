using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Interfaces;
using DAO;
using DTO;

namespace Model;
public class Client : Person, IValidateDataObject, IDataController<ClientDTO, Client>
{ 
    private Guid uuid= Guid.NewGuid();  
    public List<ClientDTO> clientDTO = new List<ClientDTO>();
    //Método para pegar a instância
    private static Client instance;
    private Client(Address address):base(address){}
    public static Client getInstance(Address address)
    {
        if (instance == null)
        {
            instance = new  Client(address);
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
        if (this.getPasswd() == null) { return false; }
        if (this.getAddress() == null) { return false; }
        return true;
    }
    public static Client convertDTOToModel(ClientDTO obj)
    {
        var client = new Client(Address.convertDTOToModel(obj.address));

        client.setName(obj.name);
        client.setDateOfBirth(obj.date_of_birth);
        client.setDocument(obj.document);
        client.setEmail(obj.email);
        client.setPhone(obj.phone);
        client.setLogin(obj.login);
        client.setPasswd(obj.passwd);
        return client;
    }
    public void delete(ClientDTO obj){}
    public bool verify(String userLogin){
        using(var context = new DaoContext())
        {
            try{
                var exist = context.Client.Where(c => c.login == userLogin).Single();
                if(exist!=null){
                    return true;
                }
                return false;
            }catch(Exception ex){
                return false;
            }
        }
    }
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
            var clientDAO = new DAO.Client
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
            context.Client.Add(clientDAO);
            // context.Entry(clientDAO.address).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.SaveChanges();
            id = clientDAO.id;
        }
        return id;
    }
    public void update(ClientDTO obj){}
    public ClientDTO findById(int id)
    {
        return new ClientDTO();
    }
    public static ClientDTO getById(int Id)
    {
        using(var context = new DaoContext())
        {
            ClientDTO clientDTO = new ClientDTO();
            var clientDAO = context.Client.Include(c=>c.address).Where(c => c.id == Id).Single();
            clientDTO.name = clientDAO.name;
            clientDTO.date_of_birth = clientDAO.date_of_birth;
            clientDTO.document = clientDAO.document;
            clientDTO.email = clientDAO.email;
            clientDTO.phone = clientDAO.phone;
            clientDTO.login = clientDAO.login;
            clientDTO.passwd = clientDAO.passwd;
            clientDTO.address = new AddressDTO();
            clientDTO.address.street = clientDAO.address.street;
            clientDTO.address.city = clientDAO.address.city;
            clientDTO.address.state = clientDAO.address.state;
            clientDTO.address.country = clientDAO.address.country;
            clientDTO.address.postal_code = clientDAO.address.postal_code;
            return clientDTO;
        }
    }
    public static object findByDocument(String doc)
    {
        using(var context = new DaoContext())
        {
            var clientInstance = context.Client.Include(c=>c.address).Where(c => c.document == doc).Single();
            return clientInstance;
        }
    }
    public static int findId(ClientDTO client)
    {
        using(var context = new DaoContext())
        {
            var clientID = context.Client.Where(c=>c.login == client.login && c.passwd == client.passwd).Single();
            return clientID.id;
        }
    }
    public static ClientDTO getByLogin(ClientDTO login)
    {
        ClientDTO clientDTO = new ClientDTO();
        using(var context = new DaoContext())
        {
            var clientDAO = context.Client.Where(c => c.login == login.login && c.passwd == login.passwd).Single();
            clientDTO.name = clientDAO.name;
            clientDTO.date_of_birth = clientDAO.date_of_birth;
            clientDTO.document = clientDAO.document;
            clientDTO.email = clientDAO.email;
            clientDTO.phone = clientDAO.phone;
            clientDTO.login = clientDAO.login;
            clientDTO.passwd = clientDAO.passwd;
            return clientDTO;
        }
    }
    public static ClientDTO FindByLogin(String login){
        ClientDTO clientDTO = new ClientDTO();
        using(var context = new DaoContext())
        {
            var clientDAO = context.Client.Where(c => c.login == login).Single();
            clientDTO.name = clientDAO.name;
            clientDTO.date_of_birth = clientDAO.date_of_birth;
            clientDTO.document = clientDAO.document;
            clientDTO.email = clientDAO.email;
            clientDTO.phone = clientDAO.phone;
            clientDTO.login = clientDAO.login;
            clientDTO.passwd = clientDAO.passwd;
            return clientDTO;
        }
    }
    public List<ClientDTO> getAll()
    {
        return this.clientDTO;
    }
    public ClientDTO convertModelToDTO()
    {
        var clientDTO = new ClientDTO();

        clientDTO.name = this.name;
        clientDTO.date_of_birth = this.date_of_birth;
        clientDTO.document = this.document;
        clientDTO.email = this.email;
        clientDTO.phone = this.phone;
        clientDTO.login = this.login;
        clientDTO.passwd = this.passwd;
        clientDTO.address = this.address.convertModelToDTO();
        return clientDTO;
    }
}
