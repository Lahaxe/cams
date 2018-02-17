using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cams.model.Core
{
    public interface ISessionFactory
    {
        ISession CreateSession();
    }
}
