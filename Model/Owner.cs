namespace Model;
public class Owner : Person
{
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
    
}