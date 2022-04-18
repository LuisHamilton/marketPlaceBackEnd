namespace Model;
using Interfaces;
public class Owner : Person, IValidateDataObject
{
    private Guid uuid = Guid.NewGuid();
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
        if (this.getAddress() == null) { return false; }
        return true;
    }

}