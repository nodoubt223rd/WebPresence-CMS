
namespace WebPresence.Common.Security.Validation
{
    public interface IValidator<T>
    {
        ValidationState Validate(T entity);
    }
}
