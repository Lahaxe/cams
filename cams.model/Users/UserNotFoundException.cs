using cams.model.Exceptions;
using System;
using System.Runtime.Serialization;

namespace cams.model.Users
{
    /// <summary>
    /// Exception thrown when <see cref="User"/> was not found.
    /// </summary>
    [Serializable]
    public class UserNotFoundException : CamsException
    {
        /// <summary>
        /// Initialize a new instance of <see cref="UserNotFoundException"/>.
        /// </summary>
        public UserNotFoundException()
            : base()
        {
        }

        /// <summary>
        /// Initialize a new instance of <see cref="UserNotFoundException"/>.
        /// </summary>
        /// <param name="message">The custom exception message.</param>
        public UserNotFoundException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initialize a new instance of <see cref="UserNotFoundException"/>.
        /// </summary>
        /// <param name="message">The custom exception message.</param>
        /// <param name="innerException">The inner exception.</param>
        public UserNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        /// Initialize a new instance of <see cref="UserNotFoundException"/> with serialization context.
        /// </summary>
        /// <remarks>
        /// Used for object deserialization.
        /// </remarks>
        /// <param name="info">The <see cref="SerializationInfo"/>.</param>
        /// <param name="context">The <see cref="StreamingContext"/>.</param>
        protected UserNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}