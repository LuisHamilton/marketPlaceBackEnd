namespace DTO;
public class ClientDTO
{ 
    //Atributos
    public String name;
    public DateTime date_of_birth;
    public String document;
    public String email;
    public String phone;
    public String login;
    public String passwd;
    public AddressDTO address; //Dependência
}