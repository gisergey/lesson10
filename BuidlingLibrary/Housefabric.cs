using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuidlingLibrary
{
       enum Matirial
       {
            дерево,
            метал
       }
      class Housefabric
      {

        public Housecs Create(Matirial mat)
        {
            switch (mat)
            {
                case Matirial.дерево:return new Woodhousecs();
                case Matirial.метал:return new Metalhouse();
                default:return null;
                    
            }

        }
      }
}
