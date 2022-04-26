namespace DAO;
using Enums;
public class Purchase
{
    //Atributos
    public int id;
    public DateTime data_purchase;
    public int payment_type;
    public int purchase_status;
    public double purchase_values;
    public String number_confirmation;
    public String number_nf;
    public Product products;
    public Client client; //Dependência
    public Store store; //Dependência
}
