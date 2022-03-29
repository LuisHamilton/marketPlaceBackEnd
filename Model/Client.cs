namespace Model;
public class Client : Person
{ 
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
}