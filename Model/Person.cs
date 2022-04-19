﻿namespace Model;
public class Person
{
    //Atributos
    protected String name;
    protected DateTime date_of_birth;
    protected String document;
    protected String email;
    protected String phone;
    protected String login;
    protected String passwd;
    protected Address address; //Dependência

    //Construtor
    public Person(Address address)
    {
        this.address = address;
    }

    //GETs e SETs
    public Address getAddress(){return this.address;}
    public void setAddress(Address address){this.address=address;}
    public String getName(){return this.name;}
    public void setName(String name){this.name=name;}
    public DateTime getDateOfBirth(){return this.date_of_birth;}
    public void setDateOfBirth(DateTime date_of_birth){this.date_of_birth=date_of_birth;}
    public String getDocument(){return this.document;}
    public void setDocument(String document){this.document=document;}
    public String getEmail(){return this.email;}
    public void setEmail(String email){this.email=email;}
    public String getPhone(){return this.phone;}
    public void setPhone(String phone){this.phone=phone;}
    public String getLogin(){return this.login;}
    public void setLogin(String login){this.login=login;}
    public String getPasswd(){return this.passwd;}
    public void setPasswd(String passwd){this.passwd=passwd;}
}