﻿namespace DAO;
public class Person
{
    //Atributos
    public int id;
    public String name;
    public DateTime date_of_birth;
    public String document;
    public String email;
    public String phone;
    public String login;
    public string passwd;
    public Address address; //Dependência
}