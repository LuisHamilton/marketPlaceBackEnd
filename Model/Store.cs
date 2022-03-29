namespace Model;
public class Store
{
    //Atributos
    private String name = "";
    private String CNPJ = "";
    private List<Purchase> purchases=new List<Purchase>();
    private Owner owner; //Dependência

    //Construtor
    public Store(Owner owner)
    {
        this.owner = owner;
    }

    //Métodos
    public List<Purchase> getPurchases(){return purchases;}
    public void addNewPurchase(Purchase purchase){ purchases.Add(purchase); } //Adiciona compra a lista de compras
    public Owner getOwner(){return owner;}
    public void setOwner(Owner owner){this.owner=owner;}
    public String getName(){return name;}
    public void setName(String name){this.name=name;}
    public String getCNPJ(){return CNPJ;}
    public void setCNPJ(String CNPJ){this.CNPJ=CNPJ;}
}
