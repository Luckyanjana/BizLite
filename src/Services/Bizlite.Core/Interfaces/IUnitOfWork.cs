using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bizlite.Core.Interfaces
{
    public interface IUnitOfWork
    {
        public IMasterRepo Master { get;}
   

        void Save();
    }
}
