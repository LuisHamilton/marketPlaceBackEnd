using System;
using System.Collections.Generic;
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
            var client = new DAO.Client
            {
                name = this.name,
                date_of_birth = this.date_of_birth,
                document = this.document,
                email = this.email,
                phone = this.phone,
                passwd = this.passwd,
                login = this.login,
                address = address
            };
            context.Client.Add(client);
            context.SaveChanges();
            id = client.id;
        }
        return id;
    }
    public void update(ClientDTO obj){}
    public ClientDTO findById(int id)
    {
        return new ClientDTO();
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
