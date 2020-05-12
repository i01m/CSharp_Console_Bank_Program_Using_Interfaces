using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankProgramUsingInterfaces
{
    public interface IAccount
    {
        void PayInFunds(decimal amount);
        bool WithdrawFunds(decimal amount);
        decimal GetBalance();
    }
        
    //regular account-withdraw as much as customer wants
    public class CustomerAccount :IAccount 
    {
        private decimal balance = 0;

        public void PayInFunds(decimal amount)
        {
            balance = balance + amount;
        }

        public bool WithdrawFunds(decimal amount)
        {
            if (balance <amount)
            { return false; }
            balance = balance - amount;
            return true;
        }

        public decimal GetBalance ()
        { return balance;}

    }

    //baby account class-customer can only withdraw no more then $10
    public class BabyAccount : IAccount
    {
        private decimal balance = 0;

        public void PayInFunds(decimal amount)
        {
            balance = balance + amount;
        }

        public bool WithdrawFunds(decimal amount)
        {
          if (amount>10)
            {return false;}
          if (amount>balance)
            { return false; }
          balance = balance - amount;
          return true;
        }

        public decimal GetBalance()
        { return balance; }

    }
    class Bank
    {
        const int MAX_CUST = 100;

        static void Main(string[] args)
        {
            IAccount[] accounts = new IAccount[MAX_CUST]; //creating array of customers,pointing to interface IAccount

            accounts[0] = new CustomerAccount(); //creating 1st customer CustomerAccount type
            accounts[0].PayInFunds(50);
            Console.WriteLine("customer 1 balance is : $"+accounts[0].GetBalance());

            accounts[1] = new BabyAccount();//creating 1st customer BabyAccount type
            accounts[1].PayInFunds(9);
            Console.WriteLine("caustomer 2(babyAccount) balance is : $" + accounts[1].GetBalance());

            Console.WriteLine();
            if (accounts[0].WithdrawFunds(40))
            { Console.WriteLine("customer1 : withdraw OK"); }
            else {Console.WriteLine("customer1 : specified amount is not available"); }

            if (accounts[1].WithdrawFunds(88)) //babyAccount could have enough funds, but cant withdraw more than $10 at a time
            { Console.WriteLine("customer2 : withdraw OK"); }
            else { Console.WriteLine("customer2 : withdraw amount reached the limit"); }

            Console.ReadKey();

         }
    }
}
