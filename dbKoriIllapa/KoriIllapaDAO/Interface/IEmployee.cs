using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoriIllapaDAO.Model;

namespace KoriIllapaDAO.Interface
{
    public interface IEmployee:IBase<Employees>
    {
        DataTable Login(string userName, string Password);
        DataTable valEmail(string email);
        Employees Get(short id);
        int firstLogin(string oldPassword, string newPassword);
        int forgotPassword(string userName, string email, string newPassword);
        short GetGenerateID();
    }
}
