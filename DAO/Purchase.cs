namespace DAO;
public class Purchase
{
    //Atributos
    public int id;
    public DateTime dataPurchase;
    public int paymentType;
    public int purchaseStatus;
    public double purchaseValues;
    public String numberConfirmation;
    public String numberNf;
    public Product products;
    public Client client; //Dependência
    public Store store; //Dependência
}
