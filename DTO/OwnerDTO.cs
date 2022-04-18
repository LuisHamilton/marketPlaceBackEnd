namespace DTO;
public class OwnerDTO
{
    //Atributos
    public String name;
    public DateTime dateOfBirth;
    public String document;
    public String email;
    public String phone;
    public String login;
    public String passwd;
    public AddressDTO address; //Dependência
}
