using apiPetMe.Models;


namespace apiPetMe.Interface.Domain
{
    public interface IRequestAdoptionDomain
    {
        string isComplete(RequestAdoption requestAdoption);
        RequestAdoption RequestAdoption(RequestAdoption requestAdoption, RequestAdoption newRequest);
    }
}
