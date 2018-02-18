using System;
using System.Runtime.Serialization;

namespace cams.model.Exceptions
{
    /// <summary>
    /// Base class for all specific CAMS exceptions.
    /// </summary>
    [Serializable]
    public class CamsException : Exception
    {
        /// <summary>
        /// Initialize a new instance of <see cref="CamsException"/>.
        /// </summary>
        public CamsException()
        {
        }

        /// <summary>
        /// Initialize a new instance of <see cref="CamsException"/>.
        /// </summary>
        /// <param name="message">The custom exception message.</param>
        public CamsException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initialize a new instance of <see cref="CamsException"/>.
        /// </summary>
        /// <param name="message">The custom exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public CamsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initialize a new instance of <see cref="CamsException"/> with serialization context.
        /// </summary>
        /// <remarks>
        /// Used for object deserialization.
        /// </remarks>
        /// <param name="info">The <see cref="SerializationInfo"/>.</param>
        /// <param name="context">The <see cref="StreamingContext"/>.</param>
        protected CamsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
