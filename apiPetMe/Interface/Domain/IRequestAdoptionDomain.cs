using apiPetMe.Models;


namespace apiPetMe.Interface.Domain
{
    public interface IRequestAdoptionDomain
    {
        string isComplete(RequestAdoption requestAdoption);
    }
}
