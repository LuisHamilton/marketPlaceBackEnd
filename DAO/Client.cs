namespace DAO;
using Interfaces;
public class Client : Person, IValidateDataObject<Client>
{ 
    public Guid uuid= Guid.NewGuid();  
    public static Client instance;
}