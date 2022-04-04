namespace Model;
public class Product
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
}
