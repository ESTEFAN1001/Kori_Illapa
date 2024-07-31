using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoriIllapaDAO.Model;

namespace KoriIllapaDAO.Interface
{
    interface ITransport: IBase<Transports>
    {
        
        short GetGenerateID();
        DataTable SelectComboTransportType();
    }
}
