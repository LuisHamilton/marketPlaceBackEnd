namespace Model;
using Interfaces;
public class Product : IValidateDataObject<Product>
{
    private String name = "";
    private double unitPrice;
    private String barCode = "";

    public String getName(){return name;}
    public void setName(String name){this.name=name;}
    public double getUnitPrice(){return unitPrice;}
    public void setUnitPrice(double unitPrice){this.unitPrice=unitPrice;}
    public String getBarCode(){return barCode;}
    public void setBarCode(String barCode){this.barCode=barCode;}

    public Boolean validateObject(Product obj)
    {
        if (obj.getName() == null) { return false; }
        if(obj.getUnitPrice() == null) { return false; }
        if (obj.getBarCode() == null) { return false; }
        return true;
    }

}
