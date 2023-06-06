using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAn
{
     public interface IState
     {
          void Handle(Item item);
     }
}
