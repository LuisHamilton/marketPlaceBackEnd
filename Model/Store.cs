using Microsoft.EntityFrameworkCore;
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
        // foreach(var purch in obj.purchases)
        // {
        //     store.addNewPurchase(Purchase.convertDTOToModel(purch));
        // }
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
            var ownerDAO = context.Owner.FirstOrDefault(o => o.id == owner);

            var storeDAO = new DAO.Store{
                name = this.name,
                CNPJ= this.CNPJ,
                owner = ownerDAO
            };

            context.Entry(storeDAO.owner).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            context.Store.Add(storeDAO);
            context.SaveChanges();

            id = storeDAO.id;
        }
         return id;
    }
    public static object getByOwner(int OwnerID){
        using(var context = new DaoContext()){
            var storeDAO = context.Store.Include(o=>o.owner).FirstOrDefault(s=>s.owner.id == OwnerID);
            return storeDAO;
        }
    }
    public static int getIdByOwner(int OwnerID){
        using(var context = new DaoContext()){
            var storeDAO = context.Store.Include(o=>o.owner).FirstOrDefault(s=>s.owner.id == OwnerID);
            return storeDAO.id;
        }
    }
    public void update(StoreDTO obj)
    {

    }
    public StoreDTO findById(int id)
    {
        return new StoreDTO();
    }public static StoreDTO getById(int Id)
    {
        using(var context = new DaoContext())
        {
            StoreDTO storeDTO = new StoreDTO();
            var storeDAO = context.Store.Include(o=>o.owner).ThenInclude(a=>a.address).Where(s => s.id == Id).Single();
            storeDTO.name = storeDAO.name;
            storeDTO.CNPJ = storeDAO.CNPJ;
            storeDTO.owner = new OwnerDTO();
            storeDTO.owner.name = storeDAO.owner.name;
            storeDTO.owner.date_of_birth = storeDAO.owner.date_of_birth;
            storeDTO.owner.document = storeDAO.owner.document;
            storeDTO.owner.email = storeDAO.owner.email;
            storeDTO.owner.phone = storeDAO.owner.phone;
            storeDTO.owner.login = storeDAO.owner.login;
            storeDTO.owner.passwd = storeDAO.owner.passwd;
            storeDTO.owner.address = new AddressDTO();
            storeDTO.owner.address.street = storeDAO.owner.address.street;
            storeDTO.owner.address.city = storeDAO.owner.address.city;
            storeDTO.owner.address.state = storeDAO.owner.address.state;
            storeDTO.owner.address.country = storeDAO.owner.address.country;
            storeDTO.owner.address.postal_code = storeDAO.owner.address.postal_code;
            return storeDTO;
        }
    }
    public static object findByCNPJ(String cnpj)
    {
        using(var context = new DaoContext())
        {
            var storeInstance = context.Store.Include(s => s.owner).Include(s => s.owner.address).Where(s => s.CNPJ == cnpj).Single();
            return storeInstance;
        }
    }
    public int findId(){
        using(var context = new DaoContext())
        {
            var storeDAO = context.Store.Where(c => c.CNPJ == this.CNPJ).Single();
            return storeDAO.id;
        }
    }
    public List<StoreDTO> getAll()
    {        
        return this.storeDTO;      
    }
    public static List<object> getAllStores()
    {
        List<object> stores = new List<object>();

        using(var context = new DaoContext())
        {
            var lojas = context.Store.Where(p => true);
            foreach(var loja in lojas)
            {
                stores.Add(loja);
            }
            return stores;
        }
    }
    public StoreDTO convertModelToDTO()
    {
        var storeDTO = new StoreDTO();

        storeDTO.name = this.name;
        storeDTO.CNPJ = this.CNPJ;
        storeDTO.owner = this.owner.convertModelToDTO();
        foreach(var purch in purchases)
        {
            storeDTO.purchases.Add(purch.convertModelToDTO());
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
    public static int getStoreId(int ownerId){
        using(var context = new DaoContext()){
            var store = context.Store.Where(s=>s.owner.id == ownerId).Single();

            return store.id;
        }
    }
    public Owner getOwner(){return owner;}
    public void setOwner(Owner owner){this.owner=owner;}
    public String getName(){return name;}
    public void setName(String name){this.name=name;}
    public String getCNPJ(){return CNPJ;}
    public void setCNPJ(String CNPJ){this.CNPJ=CNPJ;}


}
