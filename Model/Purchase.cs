namespace Model;
public class Purchase
{
    //Atributos
    private DateTime date_purchase;
    private String payment = "";
    private String number_confirmation = "";
    private String number_nf = "";
    private List<Product> products = new List<Product>();
    private Client client; //Dependência

    //Construtor
    public Purchase(Client client)
    {
        this.client = client;
    }

    //Métodos
    public List<Product> getProducts(){return products;}
    public DateTime getDate_purchase(){return date_purchase;}
    public void setDate_purchase(DateTime date_purchase){this.date_purchase=date_purchase;}
    public String getPayment(){return payment;}
    public void setPayment(String payment){this.payment=payment;}
    public String getNumber_confirmation(){return number_confirmation;}
    public void setNumber_confirmation(String number_confirmation){this.number_confirmation=number_confirmation;}
    public String getNumber_nf(){return number_nf;}
    public void setNumber_nf(String number_nf){this.number_nf=number_nf;}

}
