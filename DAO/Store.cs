namespace DAO;
using Interfaces;
public class Store : IValidateDataObject<Store>
{
    //Atributos
    public int id;
    public String name;
    public String CNPJ;
    public Purchase purchases;
    public Owner owner; //Dependência
}
