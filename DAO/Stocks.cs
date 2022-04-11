namespace DAO;
using Interfaces;
public class Stocks : IValidateDataObject<Stocks>
{
    //Atributos
    private int id;
    public int quantity;
    public Store store; //Dependência
    public Product product; //Dependência

}