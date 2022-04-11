namespace DAO;
using Interfaces;
public class Address : IValidateDataObject<Address>
{
    //Atributos
    public int id;
    public String street;
    public String city;    
    public String state;   
    public String country;
    public String postalCode;
}
