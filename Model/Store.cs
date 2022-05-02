using Enums;
using Interfaces;
using DAO;
using DTO;
namespace Model;
public class Store : IValidateDataObject, IDataController<StoreDTO, Store>
{
    //Atributos
    private String name;
    private String CNPJ;
    private Owner owner; //Dependência
    private List<Purchase> purchases=new List<Purchase>();
    public List<StoreDTO>storeDTO = new List<StoreDTO>();

    //Construtor
    public Store(Owner owner)
    {
        this.owner = owner;
    }
    //Métodos

    private Store(){

    }
    public static Store convertDTOToModel(StoreDTO obj)
    {
        //Owner.convertDTOToModel(obj.owner)
        var store = new Store();
        
        store.setName(obj.name);
        store.setCNPJ(obj.CNPJ);
        foreach(var element in obj.purchases)
        {
            store.addNewPurchase(Purchase.convertDTOToModel(element));
        }
        return store;
    }

    public void delete(StoreDTO obj)
    {

    }
    public int save(int owner)
    {       
        var id = 0;

        using(var context = new DaoContext())
        {
            var ownerDAO = context.Owner.Where(c => c.id == owner).Single();

            var storeDAO = new DAO.Store{
                name = this.name,
                CNPJ= this.CNPJ,
                owner = ownerDAO
            };

            context.Store.Add(storeDAO);
            context.Entry(storeDAO.owner).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.SaveChanges();

            id = storeDAO.id;

        }
         return id;
    }
    public void update(StoreDTO obj)
    {

    }
    public StoreDTO findById(int id)
    {

        return new StoreDTO();
    }
    public List<StoreDTO> getAll()
    {        
        return this.storeDTO;      
    }
    public StoreDTO convertModelToDTO()
    {
        var storeDTO = new StoreDTO();

        storeDTO.name = this.name;
        storeDTO.CNPJ = this.CNPJ;
        storeDTO.owner = this.owner.convertModelToDTO();
        foreach(var purchase in purchases)
        {
            storeDTO.purchases.Add(purchase.convertModelToDTO());
        }
        return storeDTO;
    }
    public Boolean validateObject()
    {
        if(this.getName()==null){return false;}
        if(this.getCNPJ() == null) { return false; }

        return true;
    }  
    public List<Purchase> getPurchases(){return purchases;}
    public void addNewPurchase(Purchase purchase)
    {
         if (!getPurchases().Contains(purchase))
         {
             this.purchases.Add(purchase);
         }
    }
    public Owner getOwner(){return owner;}
    public void setOwner(Owner owner){this.owner=owner;}
    public String getName(){return name;}
    public void setName(String name){this.name=name;}
    public String getCNPJ(){return CNPJ;}
    public void setCNPJ(String CNPJ){this.CNPJ=CNPJ;}


}
