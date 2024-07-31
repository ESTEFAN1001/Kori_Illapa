using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoriIllapaDAO.Model;

namespace KoriIllapaDAO.Interface
{
    public interface ITransportType : IBase<TransportType>
    {
        TransportType Get(byte id);
    }
}
