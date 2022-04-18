using Enums;
using Interfaces;
using DAO;
using DTO;
namespace Model;
public class Purchase : IValidateDataObject
{
    //Atributos
    private DateTime data_purchase;
    private int payment_type;
    private int purchase_status;
    public double purchase_values;
    private String number_confirmation;
    private String number_nf;
    private List<Product> products = new List<Product>();
    private Client client; //Dependência
    private Store store; //Dependência
    public List<PurchaseDTO>purchaseDTO = new List<PurchaseDTO>();

    //Métodos
    public static Purchase convertDTOToModel(PurchaseDTO obj)
    {
        var purchase=new Purchase();
        purchase.payment_type=obj.payment_type;
        purchase.data_purchase=obj.data_purchase;
        purchase.purchase_values=obj.purchase_values;
        purchase.number_confirmation=obj.number_confirmation;
        purchase.number_nf=obj.number_nf;
        return purchase;
    }

    public Boolean validateObject()
    {
        if(this.getDataPurchase() == null) { return false;}
        if(this.getPaymentType() == 0) { return false;}
        if(this.getPurchaseStatus() == 0) { return false;}
        if(this.getPurchaseValues() == 0.0) { return false;}
        if(this.getNumberConfirmation() == null) { return false;}
        if(this.getNumberNf() == null) { return false; }
        if(this.getProducts() == null) { return false;}
        if(this.getClient() == null) { return false; }
        if(this.getStore() == null) { return false; }
        return true;
    }

    public void delete(PurchaseDTO obj)
    {

    }
    public int save()
    {
        var id = 0;

        using(var context = new DaoContext())
        {
            var purchase = new DAO.Purchase{
                data_purchase = this.data_purchase,
                purchase_values= this.purchase_values,
                purchase_status = this.purchase_status,
                payment_type = this.payment_type,
                number_confirmation = this.number_confirmation,
                number_nf = this.number_nf
            };

            context.Purchase.Add(purchase);

            context.SaveChanges();

            id = purchase.id;

        }
         return id;
    }
    public void update(PurchaseDTO obj)
    {

    }


    public PurchaseDTO findById(int id)
    {

        return new PurchaseDTO();
    }

    public List<PurchaseDTO> getAll()
    {        
        return this.purchaseDTO;      
    }

   
    public PurchaseDTO convertModelToDTO()
    {
        var purchaseDTO = new PurchaseDTO();

        purchaseDTO.data_purchase = this.data_purchase;

        purchaseDTO.payment_type = this.payment_type;

        purchaseDTO.purchase_values = this.purchase_values;

        purchaseDTO.purchase_status = this.purchase_status;

        purchaseDTO.number_confirmation = this.number_confirmation;

        purchaseDTO.number_nf = this.number_nf;

        return purchaseDTO;
    }
    public void updateStatus(int PurchaseStatusEnum)
    {
        this.purchase_status = PurchaseStatusEnum;
    }

    //GETs e SETs
    public Store getStore(){return this.store;}
    public void setStore(Store store){this.store=store;}
    public Client getClient(){return this.client;}
    public void setClient(Client client){this.client=client;}
    public List<Product> getProducts(){return this.products;}
    public void setProducts(List<Product>products){this.products=products;}
    public DateTime getDataPurchase(){return this.data_purchase;}
    public void setDataPurchase(DateTime data_purchase){this.data_purchase=data_purchase;}
    public int getPaymentType(){return this.payment_type;}
    public void setPaymentType(PaymentEnum payment_type){this.payment_type=(int)payment_type;}
    public String getNumberConfirmation(){return this.number_confirmation;}
    public void setNumberConfirmation(String number_confirmation){this.number_confirmation=number_confirmation;}
    public String getNumberNf(){return this.number_nf;}
    public void setNumberNf(String number_nf){this.number_nf=number_nf;}
    public int getPurchaseStatus() => purchase_status;
    public void setPurchaseStatus(PurchaseStatusEnum purchase_status){this.purchase_status=(int)purchase_status;}
    public double getPurchaseValues() => purchase_values;
    public void setPurchaseValues(double purchase_values){this.purchase_values=purchase_values;}
}
