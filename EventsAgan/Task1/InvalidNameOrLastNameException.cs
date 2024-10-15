using System.Runtime.Serialization;

namespace EventsAgan.Task1
{
    [Serializable]
    internal class InvalidNameOrLastNameException : Exception
    {
        public InvalidNameOrLastNameException()
        {
        }

        public InvalidNameOrLastNameException(string? message) : base(message)
        {
        }

        public InvalidNameOrLastNameException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidNameOrLastNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}