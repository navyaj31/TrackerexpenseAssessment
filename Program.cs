using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Transactions;

namespace Expensetracker
{
    class Transaction
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public DateTime Date { get; set; }

    }
    class details
    {
        List<Transaction> list;
        public double Income { get; set; }
        public double Expenses { get; set; }

        public details()
        {
            list = new List<Transaction>();
        }

        public void AddTransaction()
        {


            Console.WriteLine("Enter Transaction Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Enter the description of the Transaction:  ");
            string description = Console.ReadLine();

            Console.WriteLine("Enter the amount");
            double amount = Convert.ToDouble(Console.ReadLine());


            DateTime date = new DateTime();
            try
            {
                Console.Write("Enter Date(DD/MM/YYYY): ");
                date = Convert.ToDateTime(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Enter the correct format for Date like : 12/03/2023");
            }

            if (amount >= 0)
            {
                Income += amount;
            }
            else
            {
                Expenses += Math.Abs(amount);
            }

            list.Add(new Transaction { Title = title, Description = description, Amount = amount, Date = date });
            Console.WriteLine("Transaction is successfull Added");

        }


        public void viewExpenses()
        {
            Console.WriteLine("Expenses:");
            Console.WriteLine("Title\t\tDescription\t\tAmount\t\tDate");
            foreach (Transaction transaction in list)
            {
                if (transaction.Amount < 0)
                {
                    Console.WriteLine($"{transaction.Title}\t\t{transaction.Description}\t\t{transaction.Amount}\t\t{transaction.Date}");
                }



            }
        }
        public void viewIncome()
        {
            Console.WriteLine("Income:");
            Console.WriteLine("Title\tDescription\tAmount\tDate");
            foreach (Transaction transaction in list)
            {
                if (transaction.Amount >= 0)
                {
                    Console.WriteLine($"{transaction.Title}\t{transaction.Description}\t{transaction.Amount}\t{transaction.Date}");
                }


            }
        }
        public void CheckAvailableBalance()
        {
            double Balance = Income - Expenses;
            Console.WriteLine($"Available Balance: {Balance}");
        }
    }


        internal class Program
        {
            static void Main(string[] args)
            {
                details transactiondetails = new details();
                while (true)
                {
                    Console.WriteLine("1. Add Transaction");
                    Console.WriteLine("2. View Expense");
                    Console.WriteLine("3. View Income");
                    Console.WriteLine("4. CheckAvailableBalance");
                    Console.WriteLine("Enter Your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    
                    switch (choice)
                    {
                        case 1:
                            {
                                transactiondetails.AddTransaction();
                                break;
                            }
                        case 2:
                            {
                                transactiondetails.viewExpenses();
                                break;
                            }
                        case 3:
                            {
                                transactiondetails.viewIncome();
                                break;
                            }
                        case 4:
                            {
                                transactiondetails.CheckAvailableBalance();
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid Choice");
                                break;
                            }
                    }
                }
            }
        }
    
}
