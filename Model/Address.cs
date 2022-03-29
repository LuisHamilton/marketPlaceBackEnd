namespace Model;
public class Address
{
    //Atributos
    private String street = "";
    private String city = "";    
    private String state = "";   
    private String country = "";
    private String post_code = "";

    //Métodos
    public String getStreet(){ return street; }
    public void setStreet(String street) { this.street = street; }

    public String getCity(){return city;}
    public void setCity(String city){this.city=city;}

    public String getState(){return state;}
    public void setState(String state){this.state=state;}

    public String getCountry(){return country;}
    public void setCountry(String country){this.country=country;}

    public String getPost_code(){return post_code;}
    public void setPost_code(String post_code){this.post_code=post_code;}
}
