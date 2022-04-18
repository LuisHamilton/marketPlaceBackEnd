using Enums;
using Interfaces;
using DAO;
using DTO;
namespace Model;
public class Store : IValidateDataObject
{
    //Atributos
    private String name;
    private String CNPJ;
    private List<Purchase> purchases=new List<Purchase>();
    private Owner owner; //Dependência

    public List<StoreDTO>storeDTO = new List<StoreDTO>();
    //Métodos
    public static Store convertDTOToModel(StoreDTO obj)
    {
        var store=new Store();
        store.name=obj.name;
        store.CNPJ=obj.CNPJ;
        return store;
    }
    public List<Purchase> getPurchases(){return purchases;}
    public void addNewPurchase(Purchase purchase){ purchases.Add(purchase); } //Adiciona compra a lista de compras
    public Owner getOwner(){return owner;}
    public void setOwner(Owner owner){this.owner=owner;}
    public String getName(){return name;}
    public void setName(String name){this.name=name;}
    public String getCNPJ(){return CNPJ;}
    public void setCNPJ(String CNPJ){this.CNPJ=CNPJ;}

    public Boolean validateObject()
    {
        if (this.getName() == null) { return false; }
        if (this.getCNPJ() == null) { return false; }
        if (this.getPurchases() == null) { return false; }
        if (this.getOwner() == null) { return false; }
        return true;
    }
}
