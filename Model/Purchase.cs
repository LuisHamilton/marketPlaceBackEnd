using Enums;

namespace Model;
public class Purchase
{
    //Atributos
    private DateTime dataPurchase;
    private int paymentType;
    private int purchaseStatus;
    public double purchaseValues = 0;
    private String numberConfirmation = "";
    private String numberNf = "";
    private List<Product> products = new List<Product>();
    private Client client; //Dependência

    //Métodos
    public Client getClient(){return this.client;}
    public void setClient(Client client){this.client=client;}
    public List<Product> getProducts(){return this.products;}
    public void setProducts(List<Product>products){this.products=products;}
    public DateTime getDataPurchase(){return this.dataPurchase;}
    public void setDataPurchase(DateTime dataPurchase){this.dataPurchase=dataPurchase;}
    public int getPaymentType(){return this.paymentType;}
    public void setPaymentType(PaymentEnum paymentType){this.paymentType=(int)paymentType;}
    public String getNumberConfirmation(){return this.numberConfirmation;}
    public void setNumberConfirmation(String numberConfirmation){this.numberConfirmation=numberConfirmation;}
    public String getNumberNf(){return this.numberNf;}
    public void setNumberNf(String numberNf){this.numberNf=numberNf;}
    public int getPurchaseStatus() => purchaseStatus;
    public void setPurchaseStatus(PurchaseStatusEnum purchaseStatus){this.purchaseStatus=(int)purchaseStatus;}
    public double getPurchaseValues() => purchaseValues;
    public void setPurchaseValues(double purchaseValues){this.purchaseValues=purchaseValues;}
}
