namespace DTO;
public class StoreDTO
{
    //Atributos
    public String name;
    public String CNPJ;
    public List<PurchaseDTO> purchases = new List<PurchaseDTO>();
    public OwnerDTO owner; //Dependência
}
