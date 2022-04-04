namespace Model;
using Interfaces;
public class Client : Person, IValidateDataObject<Client>
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
    public Boolean validateObject(Client obj)
    {
        if (obj.getName() == null) { return false; }
        if (obj.getAge() == null) { return false; }
        if (obj.getDocument() == null) { return false; }
        if (obj.getEmail() == null) { return false; }
        if (obj.getPhone() == null) { return false; }
        if (obj.getLogin() == null) { return false; }
        if (obj.getAddress() == null) { return false; }
        return true;
    }
}