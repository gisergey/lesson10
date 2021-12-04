using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fabricslist1
{
    enum tipsbank
    {
        сбербанк,
        альфабанк
    }
    class Bankaccountfabric
    {
        public List<Object> allaccounts = new List<Object>();
        public Bankaccounjt Creacte(tipsbank a)
        {
            switch (a)
            {
                case tipsbank.альфабанк:return new Alphabank();
                case tipsbank.сбербанк: return new Sberbank();
                default:return null;
            }
        }
    }
}
