using HealthCard.Models;

namespace HealthCard.Interfaces;

public interface IHealthCardService
{
    Models.HealthCard CreateHealthCard(string clientId, string clinicId, HealthCardInfo healthCardInfo);
    Models.HealthCard GetHealthCardById(string healthCardId);
    Models.HealthCard GetHealthCardByClientId(string clientId);
    Models.HealthCard GetHealthCardByCpr(string cpr);
    Models.HealthCard UpdateHealthCardById(string healthCardId, HealthCardInfo healthCardInfo);
    bool DeleteHealthCardById(string healthCardId);
}
