namespace DAO;
using Interfaces;
public class Owner : Person, IValidateDataObject<Owner>
{
    public Guid uuid = Guid.NewGuid();
    public static Owner instance;
}