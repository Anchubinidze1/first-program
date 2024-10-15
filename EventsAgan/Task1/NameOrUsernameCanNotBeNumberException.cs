using System.Runtime.Serialization;

namespace EventsAgan.Task1
{
    [Serializable]
    internal class NameOrUsernameCanNotBeNumberException : Exception
    {
        public NameOrUsernameCanNotBeNumberException()
        {
        }

        public NameOrUsernameCanNotBeNumberException(string? message) : base(message)
        {
        }

        public NameOrUsernameCanNotBeNumberException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NameOrUsernameCanNotBeNumberException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}