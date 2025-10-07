using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day2
{
    internal class BankAccount
    {
        // Private field — cannot be accessed directly from outside
        private decimal balance;

        // Public property — provides controlled access
        public decimal Balance
        {
            get { return balance; }   // only read access
            private set { balance = value; }  // only class can modify
        }

        // Public method — allows controlled deposits
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Deposited ₹{amount}. New Balance: ₹{Balance}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be greater than 0.");
            }
        }

        // Public method — allows controlled withdrawals
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be greater than 0.");
            }
            else if (amount > Balance)
            {
                Console.WriteLine("Insufficient balance.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Withdrew ₹{amount}. New Balance: ₹{Balance}");
            }
        }
    }
}
