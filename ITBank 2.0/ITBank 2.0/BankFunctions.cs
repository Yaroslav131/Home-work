using BankAccount;
using BankCards;
using BankAccounts;
using OutputLine;
using System;
using static System.Console;

namespace BankFunctions
{
    public class BankFunction : Accounts
    {
        public enum CardFunctions
        {
            AddMoney = 1,
            GetMoney,
            ShowMoney,
            TransitMoney,
        }

        public enum TypeTransit
        {
            TransitMoney = 1,
            TransitMoneyOhterAccount
        }

        public enum SurgeryConditons
        {
            Yes = 1,
            No
        }

        public static int TypeTransition { get; set; }
        public static int SurgeryConditon { get; set; }
        public static int FunctionNumber { get; set; }
        public static bool UnknownKey { get; set; }

        private int numbersAccounts;
        private int numbersCards;
        private int idCard;
        private bool linkCard;

        public void CreatAccuonts()
        {
            WriteLine("How mach do you want accounts?");

            while (!int.TryParse(ReadLine(), out numbersAccounts))
            {
                Output.InformMistake();
            }

            Accounts.accounts = new Aсcount[numbersAccounts];

            for (int i = 0; i < numbersAccounts; i++)
            {
                Accounts.accounts[i] = new Aсcount();
            }
        }

        public void ChooseFunction()
        {
            do
            {
                switch (ReadKey().Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        FunctionNumber = (int)CardFunctions.AddMoney;
                        UnknownKey = false;
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        FunctionNumber = (int)CardFunctions.GetMoney;
                        UnknownKey = false;
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        FunctionNumber = (int)CardFunctions.ShowMoney;
                        UnknownKey = false;
                        break;

                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        FunctionNumber = (int)CardFunctions.TransitMoney;
                        UnknownKey = false;
                        break;

                    default:
                        UnknownKey = true;
                        break;
                }
            }
            while (UnknownKey);
        }

        public void LinkCards()
        {
            do
            {
                WriteLine("Choose how mach you want have debit cards. ");

                while (!int.TryParse(ReadLine(), out numbersCards))
                {
                    Output.InformMistake();
                }

                Clear();

                for (int counter = 0; counter < numbersCards; counter++)
                {
                    Cards.DebitsCards = new int[numbersCards];

                    WriteLine("Choose account for debit card. ");

                    while (!int.TryParse(ReadLine(), out idCard))
                    {
                        Output.InformMistake();
                    }

                    if (idCard > Accounts.accounts.Length || idCard < 1)
                    {
                        Output.InformMistake();

                        linkCard = true;
                    }
                    else
                    {
                        Cards.DebitsCards[counter] = idCard - 1;
                        Accounts.accounts[idCard - 1].Money = 0;
                        linkCard = false;
                    }
                }

                Clear();

                WriteLine("Choose how mach you want have credit card. ");

                while (!int.TryParse(ReadLine(), out numbersCards))
                {
                    Output.InformMistake();
                }

                Clear();

                for (int counter = 0; counter < numbersCards; counter++)
                {
                    Cards.KreditsCards = new int[numbersCards];

                    WriteLine("Choose  account for credit card. ");

                    while (!int.TryParse(ReadLine(), out idCard))
                    {
                        Output.InformMistake();
                    }

                    if (idCard > Accounts.accounts.Length || idCard < 1)
                    {
                        Output.InformMistake();

                        linkCard = true;
                    }
                    else
                    {
                        Cards.KreditsCards[counter] = idCard - 1;
                        Accounts.accounts[idCard - 1].Money = 0;
                        linkCard = false;
                    }
                }

                if (linkCard == true)
                {
                    WriteLine("We have problem with registration,try again.");
                }
            }
            while (linkCard);
        }

        public void ChooseTypeTransitoin()
        {
            Output.ShowTypeTransitions();

            do
            {
                switch (ReadKey().Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        TypeTransition = (int)TypeTransit.TransitMoney;
                        UnknownKey = false;
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        TypeTransition = (int)TypeTransit.TransitMoneyOhterAccount;
                        UnknownKey = false;
                        break;

                    default:
                        UnknownKey = true;
                        break;
                }
            }
            while (UnknownKey);
        }

        public void ChooreSurgery()
        {

            Output.ShowSurgery();

            do
            {
                switch (ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        SurgeryConditon = (int)SurgeryConditons.Yes;
                        UnknownKey = false;
                        break;

                    case ConsoleKey.Escape:
                        SurgeryConditon = (int)SurgeryConditons.No;
                        UnknownKey = false;
                        break;

                    default:
                        UnknownKey = true;
                        break;
                }
            }
            while (UnknownKey);
        }
    }
}
