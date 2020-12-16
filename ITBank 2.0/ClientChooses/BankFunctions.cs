using BankAccounts;
using OutputLine;
using Values;
using static System.Console;
namespace BankFunctions
{
    public class BankFunction
    {
        private int numbersAccounts;
        private int numbersCards;
        private int idCard;

        private int typeCard;
        private int numberCard;
        private int surgeryConditon;
        internal int FunctionNumber;

        public bool Link { get; set; }
        public int[] ArrCardD { get; set; }
        public int[] ArrCardK { get; set; }
        public bool Credit { get; set; }


        readonly Accounts accounts = new Accounts();
        readonly Value value = new Value();
        public void CreateAccounts()
        {
            do
            {
                WriteLine("Choose numbers of acounts, what you want to create. ");
                while (!int.TryParse(ReadLine(), out numbersAccounts))
                {
                    WriteLine("Write correctly,it's not number");
                }
                accounts.CreatAccuonts(numbersAccounts);

                Clear();

                WriteLine("Choose how mach you want have debit cards. ");
                while (!int.TryParse(ReadLine(), out numbersCards))
                {
                    WriteLine("Write correctly,it's not number");
                }
                LinkCardD(numbersCards);

                Clear();

                WriteLine("Choose how mach you want have credit card. ");
                while (!int.TryParse(ReadLine(), out numbersCards))
                {
                    WriteLine("Write correctly,it's not number");
                }

                LinkCardK(numbersCards);

                Clear();

                if (Link == true)
                {
                    WriteLine("We have problem with registration,try again.");
                }
            } while (Link);
        }
        public void LinkCardD(int numbersCards)
        {
            for (int i = 0; i < numbersCards; i++)
            {
                ArrCardD = new int[numbersCards];
                WriteLine("Choose  acount for debit card. ");
                while (!int.TryParse(ReadLine(), out idCard))
                {
                    WriteLine("Write correctly,it's not number.");
                }

                if (idCard > accounts.accounts.Length || idCard < 1)
                {
                    WriteLine("We dont  have this account. ");
                    Link = true;
                }
                else
                {
                    ArrCardD[i] = idCard - 1;
                    accounts.accounts[idCard - 1].Money = 0;
                }
            }
        }
        public void LinkCardK(int n)
        {
            for (int i = 0; i < n; i++)
            {
                ArrCardK = new int[n];

                WriteLine("Choose  acount for Credit card. ");
                while (!int.TryParse(ReadLine(), out idCard))
                {
                    WriteLine("Write correctly,it's not number.");
                }

                if (idCard > accounts.accounts.Length || idCard < 1)
                {
                    WriteLine("We dont  have this account.");
                    Link = true;
                }
                else
                {
                    ArrCardK[i] = idCard - 1;
                    accounts.accounts[idCard - 1].Money = 0;
                }
            }
        }

        public void ChooseCard()
        {
            WriteLine("Choose number of card");

            while (!int.TryParse(ReadLine(), out numberCard))
            {
                Output.InformMistake();
            }

            WriteLine("Choose card \n1)Debit.\n2)Kredit.");

            while (!int.TryParse(ReadLine(), out typeCard))
            {
                Output.InformMistake();
            }
        }

        public void ChooreSur()
        {
            WriteLine("Would you like to do another surgery?\n1)Yes.\n2)No.");
            while (!int.TryParse(ReadLine(), out surgeryConditon))
            {
                Output.InformMistake();
            }
        }

        public void ChooseFunction()
        {
            while (!int.TryParse(ReadLine(), out FunctionNumber))
            {
                WriteLine("Write correctly,it's not number");
            }
        }
    }
}
