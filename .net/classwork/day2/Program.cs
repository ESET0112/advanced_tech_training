namespace day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");

            //Human human1 = new Human("Nilanjan",20);
            //human1.eat();
            BankAccount account = new BankAccount();

            account.Deposit(1000);
            account.Withdraw(200);
            account.Withdraw(1000);

            // Not allowed — balance is private
            // account.balance = 5000;  // Compile-time error

            // Read allowed (through property)
            Console.WriteLine($"Final Balance: ₹{account.Balance}");



        }
    }

}
