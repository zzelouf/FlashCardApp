using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using flashcardApp.Models;

namespace flashcardApp.DAO
{
    public interface IModuleDAO
    {
        IList<Module> GetModules();
    }
}
