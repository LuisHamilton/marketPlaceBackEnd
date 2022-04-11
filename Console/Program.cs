using DAO;

using var context = new DaoContext();
context.Database.EnsureCreated();

context.Address.Add(new Address
{
    street = "Rua Alberto Rutz",
    city = "Curitiba",
    state = "Paraná",
    country = "Brasil",
    postalCode = "81320-280"
});

context.SaveChanges();