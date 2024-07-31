using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoriIllapaDAO.Model;

namespace KoriIllapaDAO.Interface
{
    public interface ISupplier : IBase<Suppliers>
    {
        Suppliers Get(short id);
        short GetGenerateID();

        DataTable SelectComboSupplier();
    }
}
