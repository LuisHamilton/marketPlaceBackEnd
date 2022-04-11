namespace DAO;
public class Store
{
    //Atributos
    public int id;
    public String name;
    public String CNPJ;
    public Purchase purchases;
    public Owner owner; //Dependência
}
