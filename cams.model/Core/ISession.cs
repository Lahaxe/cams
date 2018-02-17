using System;

namespace cams.model.Core
{
    public interface ISession : IDisposable
    {
        void Connect();
    }
}
