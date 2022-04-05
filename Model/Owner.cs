namespace Model;
using Interfaces;
public class Owner : Person, IValidateDataObject<Owner>
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
    public Boolean validateObject(Owner obj)
    {
        if (obj.getName() == null) { return false; }
        if (obj.getAge() == 0) { return false; }
        if (obj.getDocument() == null) { return false; }
        if (obj.getEmail() == null) { return false; }
        if (obj.getPhone() == null) { return false; }
        if (obj.getLogin() == null) { return false; }
        if (obj.getAddress() == null) { return false; }
        return true;
    }

}