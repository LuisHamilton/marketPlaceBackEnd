﻿namespace Model;
public class Person
{
    //Atributos
    protected String name;
    protected DateTime dateOfBirth;
    protected String document;
    protected String email;
    protected String phone;
    protected String login;
    protected Address address; //Dependência

    //Construtor
    public Person(Address address)
    {
        this.address = address;
    }

    //Métodos
    public Address getAddress(){return address;}
    public void setAddress(Address address){this.address=address;}
    public String getName(){return name;}
    public void setName(String name){this.name=name;}
    public DateTime getDateOfBirth(){return dateOfBirth;}
    public void setDateOfBirth(DateTime dateOfBirth){this.dateOfBirth=dateOfBirth;}
    public String getDocument(){return document;}
    public void setDocument(String document){this.document=document;}
    public String getEmail(){return email;}
    public void setEmail(String email){this.email=email;}
    public String getPhone(){return phone;}
    public void setPhone(String phone){this.phone=phone;}
    public String getLogin(){return login;}
    public void setLogin(String login){this.login=login;}

    
}