using System;
using System.Runtime.Serialization;

namespace snipetrain_api.Exceptions
{
    [Serializable]
    public class PlayerNotFoundException : Exception
    {
        public PlayerNotFoundException() { }
        public PlayerNotFoundException(string message) : base(message) { }
        public PlayerNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected PlayerNotFoundException(
            SerializationInfo info,
            StreamingContext context) : base(info, context) { }
    }
}