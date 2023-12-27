using System.Runtime.Serialization;

namespace Speridian.EMS.Exceptions
{
    public class EMSException : ApplicationException
    {
        public EMSException()
        {
        }

        public EMSException(string? message) : base(message)
        {
        }

        public EMSException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EMSException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}