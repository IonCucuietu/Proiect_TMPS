﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectDeAn.State
{
     public class AvailableState : IState
     {
          public void Handle(Item item)
          {
               Console.WriteLine($"Itemul '{item.Title}' este disponibil.");
          }
     }
}
