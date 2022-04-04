namespace Model;
public class Purchase
{
    //Atributos
    private DateTime dataPurchase;
    private String paymentType = "";
    private String numberConfirmation = "";
    private String numberNf = "";
    private List<Product> products = new List<Product>();
    private Client client; //Dependência

    //Métodos
    public List<Product> getProducts(){return products;}
    public void setProducts(List<Product>products){this.products=products;}
    public DateTime getDataPurchase(){return dataPurchase;}
    public void setDataPurchase(DateTime dataPurchase){this.dataPurchase=dataPurchase;}
    public String getPaymentType(){return paymentType;}
    public void setPaymentType(String paymentType){this.paymentType=paymentType;}
    public String getNumberConfirmation(){return numberConfirmation;}
    public void setNumberConfirmation(String numberConfirmation){this.numberConfirmation=numberConfirmation;}
    public String getNumberNf(){return numberNf;}
    public void setNumberNf(String numberNf){this.numberNf=numberNf;}

}
