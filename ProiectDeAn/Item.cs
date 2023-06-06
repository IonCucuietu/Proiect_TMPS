using ProiectDeAn.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAn
{
     public abstract class Item
     {
          public virtual string Title { get; set; }
          public IState CurrentState { get; set; }

          public Item()
          {
               CurrentState = new AvailableState(); // Starea implicită este "disponibil"
          }

          public void Borrow()
          {
               CurrentState.Handle(this);
               CurrentState = new BorrowedState();
          }

          
     }

}
