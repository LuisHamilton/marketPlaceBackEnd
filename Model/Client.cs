using System;
using System.Collections.Generic;
using Interfaces;
using DAO;
using DTO;

namespace Model;
public class Client : Person, IValidateDataObject//, IDataController<ClientDTO, Person>
{ 
    private Guid uuid= Guid.NewGuid();  
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
    // public List<ClientDTO> clientDTO = new List<ClientDTO>();
    // public static Client convertDTOToModel(ClientDTO obj)
    // {
    //     return new Person(obj.name, obj.date_of_birth, obj.document, obj.email, obj.phone, obj.login, obj.address);
    // }
    public Boolean validateObject()
    {
        if (this.getName() == null) { return false; }
        if (this.getDateOfBirth() == null) { return false; }
        if (this.getDocument() == null) { return false; }
        if (this.getEmail() == null) { return false; }
        if (this.getPhone() == null) { return false; }
        if (this.getLogin() == null) { return false; }
        if (this.getAddress() == null) { return false; }
        return true;
    }
}