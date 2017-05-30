
namespace WebPresence.Core.Exceptions
{
    public class NotAllowedExpressionException : WebPresenceException
    {
        public NotAllowedExpressionException(string name) :
                base(string.Format("SafeQuery doesn't allow {0}", name))
        {

        }
        public NotAllowedExpressionException() :
            base(string.Format("SafeQuery allows only logical operators, comparison operators, access to properties, StartsWith, EndsWith, and Contains"))
        {

        }
    }
}
