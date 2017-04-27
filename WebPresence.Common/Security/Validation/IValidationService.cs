
namespace WebPresence.Common.Security.Validation
{
    public interface IValidationService
    {
        ValidationState Validate<T>(T model);
    }
}
