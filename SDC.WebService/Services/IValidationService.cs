using SDC.WebService.Models;

namespace SDC.WebService.Services
{
    public interface IValidationService
    {
        StatusInfo ValidateXml(string xmlFile);
    }
}
