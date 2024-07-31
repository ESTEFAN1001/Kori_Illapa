using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoriIllapaDAO.Model;

namespace KoriIllapaDAO.Interface
{
    public interface IFeature : IBase<Features>
    {
        Features Get(short id);
        void Insert(Transports t, Features f);
        void Update(Transports t, Features f);
        short GetGenerateId();
        DataTable Search(string data);
    }
}
