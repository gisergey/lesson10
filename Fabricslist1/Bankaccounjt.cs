
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fabricslist1
{
    public enum accounts
    {
        corrent,
        saving
    }
    class Bankaccounjt
    {
        private decimal balance;
        private accounts account_type;
        private Guid id;
        private Queue<BankTransaction> Transactions = new Queue<BankTransaction>();

        internal Bankaccounjt(accounts type)
        {
            balance = 0;
            id = Guid.NewGuid();
            account_type = type;
        }
        internal Bankaccounjt(decimal money = 0)
        {
            id = Guid.NewGuid();
            balance = money;
            account_type = (accounts)0;
        }
        internal Bankaccounjt(decimal money, accounts type)
        {
            id = Guid.NewGuid();
            balance = money;
            account_type = type;
        }

        public void Sendmoney(Bankaccounjt otherbill, decimal how_much_to_send)
        {
            if (balance > how_much_to_send)
            {
                otherbill.topaccount(how_much_to_send);
                this.withdrawaccount(how_much_to_send);
            }
        }

        public void topaccount(decimal money)
        {
            BankTransaction now = new BankTransaction(money);
            Transactions.Enqueue(now);
            balance += money;
        }
        public void withdrawaccount(decimal money)
        {
            if (money < balance)
            {
                BankTransaction now = new BankTransaction((-1) * money);
                Transactions.Enqueue(now);
                balance -= money;
            }
        }
        public void infoaccount()
        {
            Console.WriteLine($"Type {(accounts)account_type}\nID - {id}\nmoney = {balance}$");
        }
        public void Despose()
        {
            using (StreamWriter text = new StreamWriter("Transaction.txt", true))
            {
                foreach (BankTransaction tran in Transactions)
                {
                    text.WriteLine($"{tran.Money} {tran.Time}");
                    GC.SuppressFinalize(Transactions);
                }
            }

        }

    }
}
