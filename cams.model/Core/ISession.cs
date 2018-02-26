using System;

namespace cams.model.Core
{
    /// <summary>
    /// Defines the session base.
    /// </summary>
    public interface ISession : IDisposable
    {
        void Connect();
    }
}