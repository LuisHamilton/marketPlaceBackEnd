namespace DAO;
using Interfaces;
public class Product : IValidateDataObject<Product>
{
    public int id;
    public String name;
    public double unitPrice;
    public String barCode;
}
