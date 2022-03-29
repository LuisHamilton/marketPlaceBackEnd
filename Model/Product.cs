namespace Model;
public class Product
{
    private String name = "";
    private double unit_price;
    private String bar_code = "";

    public String getName(){return name;}
    public void SetName(String name){this.name=name;}
    public double getUnit_price(){return unit_price;}
    public void setUnit_price(double unit_price){this.unit_price=unit_price;}
    public String getBar_code(){return bar_code;}
    public void setBar_code(String bar_code){this.bar_code=bar_code;}
}
