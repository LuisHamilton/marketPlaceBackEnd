using Enums;
namespace Model;
using Interfaces;
public class Purchase : IValidateDataObject<Purchase>
{
    //Atributos
    private DateTime dataPurchase;
    private int paymentType;
    private int purchaseStatus;
    public double purchaseValues;
    private String numberConfirmation;
    private String numberNf;
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

    public Boolean validateObject(Purchase obj)
    {
        if(obj.getDataPurchase() == null) { return false;}
        if(obj.getPaymentType() == 0) { return false;}
        if(obj.getPurchaseStatus() == 0) { return false;}
        if(obj.getPurchaseValues() == 0.0) { return false;}
        if(obj.getNumberConfirmation() == null) { return false;}
        if (obj.getNumberNf() == null) { return false; }
        if (obj.getProducts() == null) { return false;}
        if (obj.getClient() == null) { return false; }
        return true;
    }

    public void updateStatus(int PurchaseStatusEnum)
    {
        this.purchaseStatus = PurchaseStatusEnum;
    }
}
