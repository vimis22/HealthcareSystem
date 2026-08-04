using HealthCard.Interfaces;
using HealthCard.Models;

namespace HealthCard.Services;

public class HealthCardService : IHealthCardService
{
    public Models.HealthCard CreateHealthCard(string clientId, string clinicId, HealthCardInfo healthCardInfo)
    {
        throw new NotImplementedException();
    }

    public Models.HealthCard GetHealthCardById(string healthCardId)
    {
        throw new NotImplementedException();
    }

    public Models.HealthCard GetHealthCardByClientId(string clientId)
    {
        throw new NotImplementedException();
    }

    public Models.HealthCard GetHealthCardByCpr(string cpr)
    {
        throw new NotImplementedException();
    }

    public Models.HealthCard UpdateHealthCardById(string healthCardId, HealthCardInfo healthCardInfo)
    {
        throw new NotImplementedException();
    }

    public bool DeleteHealthCardById(string healthCardId)
    {
        throw new NotImplementedException();
    }
}
