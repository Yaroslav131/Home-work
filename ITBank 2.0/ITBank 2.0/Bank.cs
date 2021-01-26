using System;
using static System.Console;

namespace ITBank_2._0
{
    public class Bank
    {
        public enum CardFunctions
        {
            AddMoney = 1,
            GetMoney,
            ShowMoney,
            TransitMoney,
        }

        public enum TypeCards
        {
            Debit = 1,
            Credit
        }

        public enum TypeTransitions
        {
            TransitMoney = 1,
            TransitMoneyOhterAccount
        }

        public enum NewOperationOptions
        {
            Yes = 1,
            No
        }

        private long numberOfAccounts;
        private long numberOfCards;
        private int typeOfCard;
        private int positionInCardArray;
        private bool wrongСonnectionOfCard;
        private bool unknownKey;
        private int counter;
        private int counter2;

        public static bool NegativeBallance { get; set; }
        public static bool WrongNumberOfAccount { get; set; }
        public static bool RightNumberOfAccount { get; set; }
        public static bool Credit { get; set; }
        public static int TypeOfTransition { get; set; }
        public static int NumberOfNewOperationOptions { get; set; }
        public static int NumberOfCardFunction { get; set; }
        public static bool ReconnectionCard { get; set; }
        public static int[] SomeTypeOfCards { get; set; }

        internal static double money;
        internal static long accountForTransit;
        internal static long numberCard;

        private string recipientName;
        private string recipientSurname;
        private string recipientLastname;
        private string recipientAccountNumber;
        private int[] arrayRecipientNumber;

        private const int MaxLenghtPassword = 20;
        private const int ConvertToArrayStyle = 1;

        public Bank()
        {
            RightNumberOfAccount = false;
            WrongNumberOfAccount = false;
        }

        public void CreateAccounts()
        {
            WriteLine("How mach do you want accounts?");

            while (!long.TryParse(ReadLine(), out numberOfAccounts) || numberOfAccounts <= 0)
            {
                Clear();

                Output.InformMistake();
            }

            BankStorage.AccountsScore = new double[numberOfAccounts];
        }

        public void LinkCards()
        {
            for (counter = 1; counter <= Enum.GetNames(typeof(TypeCards)).Length; counter++)
            {
                do
                {
                    if (counter == (int)TypeCards.Debit)
                    {
                        WriteLine("Choose how mach you want have debit card. ");
                    }
                    else if (counter == (int)TypeCards.Credit)
                    {
                        WriteLine("Choose how mach you want have credit card. ");
                    }

                    while (!long.TryParse(ReadLine(), out numberOfCards))
                    {
                        Clear();

                        Output.InformMistake();
                    }

                    if (counter == (int)TypeCards.Debit)
                    {
                        BankStorage.DebitCards = new int[numberOfCards];
                    }
                    else if (counter == (int)TypeCards.Credit)
                    {
                        BankStorage.CreditCards = new int[numberOfCards];
                    }

                    if (numberOfCards == 0)
                    {
                        wrongСonnectionOfCard = false;
                    }
                    else
                    {
                        for (counter2 = 0; counter2 < numberOfCards; counter2++)
                        {
                            if (counter == (int)TypeCards.Debit)
                            {
                                WriteLine("Choose account for debit card.");
                            }
                            else if (counter == (int)TypeCards.Credit)
                            {
                                WriteLine("Choose account for credit card.");
                            }

                            while (!int.TryParse(ReadLine(), out positionInCardArray) || positionInCardArray <= 0)
                            {
                                Clear();

                                Output.InformMistake();
                            }

                            positionInCardArray -= ConvertToArrayStyle;

                            if (positionInCardArray > BankStorage.AccountsScore.Length || positionInCardArray < 0)
                            {
                                Output.InformMistake();

                                wrongСonnectionOfCard = true;
                            }
                            else
                            {
                                if (counter == (int)TypeCards.Debit)
                                {
                                    BankStorage.DebitCards[counter2] = positionInCardArray;
                                }
                                else if (counter == (int)TypeCards.Credit)
                                {
                                    BankStorage.CreditCards[counter2] = positionInCardArray;
                                }

                                BankStorage.AccountsScore[positionInCardArray] = 0;
                                wrongСonnectionOfCard = false;
                            }
                        }

                        if (wrongСonnectionOfCard == true)
                        {
                            WriteLine("We have problem with registration,try again.");
                        }
                    }
                }
                while (wrongСonnectionOfCard);
            }
        }

        public void ChooseCardFunction()
        {
            do
            {
                Output.ShowCardFunctions();

                switch (ReadKey().Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        NumberOfCardFunction = (int)CardFunctions.AddMoney;
                        unknownKey = false;
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        NumberOfCardFunction = (int)CardFunctions.GetMoney;
                        unknownKey = false;
                        break;

                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        NumberOfCardFunction = (int)CardFunctions.ShowMoney;
                        unknownKey = false;
                        break;

                    case ConsoleKey.NumPad4:
                    case ConsoleKey.D4:
                        NumberOfCardFunction = (int)CardFunctions.TransitMoney;
                        unknownKey = false;
                        break;

                    default:
                        unknownKey = true;
                        break;
                }
            }
            while (unknownKey);
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
                        TypeOfTransition = (int)TypeTransitions.TransitMoney;
                        unknownKey = false;
                        break;

                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        TypeOfTransition = (int)TypeTransitions.TransitMoneyOhterAccount;
                        unknownKey = false;
                        break;

                    default:
                        unknownKey = true;
                        break;
                }
            }
            while (unknownKey);
        }

        public void StartNewOperation()
        {
            Output.ShowNewOperationOptions();

            do
            {
                switch (ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        NumberOfNewOperationOptions = (int)NewOperationOptions.Yes;
                        unknownKey = false;
                        break;

                    case ConsoleKey.Escape:
                        NumberOfNewOperationOptions = (int)NewOperationOptions.No;
                        unknownKey = false;
                        break;

                    default:
                        unknownKey = true;
                        break;
                }
            }
            while (unknownKey);
        }

        public void RecreateCard()
        {
            Output.ShowReconnectionOptions();

            do
            {
                switch (ReadKey().Key)
                {
                    case ConsoleKey.Enter:
                        ReconnectionCard = true;
                        unknownKey = false;
                        break;

                    case ConsoleKey.Escape:
                        ReconnectionCard = false;
                        unknownKey = false;
                        break;

                    default:
                        unknownKey = true;
                        break;
                }
            }
            while (unknownKey);
        }

        public void ChooseCard()
        {
            do
            {
                Output.ShowTypeOfCard();

                switch (ReadKey().Key)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        typeOfCard = (int)TypeCards.Debit;
                        unknownKey = false;

                        if (BankStorage.DebitCards.Length == 0)
                        {
                            Clear();

                            WriteLine("You don't have card this type ");

                            unknownKey = true;
                        }
                        break;

                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        typeOfCard = (int)TypeCards.Credit;
                        unknownKey = false;

                        if (BankStorage.CreditCards.Length == 0)
                        {
                            Clear();

                            WriteLine("You don't have  card this type ");

                            unknownKey = true;
                        }
                        break;

                    default:
                        unknownKey = true;
                        break;
                }
            }
            while (unknownKey);

            Clear();

            WriteLine("Choose number of card");

            while (!long.TryParse(ReadLine(), out numberCard))
            {
                Output.InformMistake();
            }

            numberCard -= ConvertToArrayStyle;

            CheckTypeCard();

            CheckRightAccount();

            CheckCredit();
        }

        public void ChooseAccountForTransit()
        {
            WriteLine("Choose account, which you want to transfer money.");

            while (!long.TryParse(ReadLine(), out accountForTransit))
            {
                Output.InformMistake();
            }

            accountForTransit -= ConvertToArrayStyle;

            CheckNumberAccountForTrans();
        }

        public void SetSum()
        {
            WriteLine("How match money?");

            while (!double.TryParse(ReadLine(), out money) || money < 0)
            {
                Output.InformMistake();
            }

            if (NumberOfCardFunction == (int)CardFunctions.GetMoney || NumberOfCardFunction == (int)CardFunctions.TransitMoney)
            {
                CheckNegativeBallance();
            }
        }

        public void GetRecipientData()
        {
            WriteLine("Write name of a recipient.");

            recipientName = ReadLine();

            WriteLine("Write surname of a recipient.");

            recipientSurname = ReadLine();

            WriteLine("Write lastname of a recipient.");

            recipientLastname = ReadLine();

            WriteLine("Write account number of a recipient (20 numbers). ");

            do
            {
                recipientAccountNumber = ReadLine();
                char[] arrScoreNumChar = recipientAccountNumber.ToCharArray();
                arrayRecipientNumber = new int[arrScoreNumChar.Length];

                for (int counter = 0; counter < arrayRecipientNumber.Length; counter++)
                {
                    while (!int.TryParse(arrScoreNumChar[counter].ToString(), out arrayRecipientNumber[counter]) || money < 0)
                    {
                        Output.InformMistake();
                    }
                }

                if (arrayRecipientNumber.Length < MaxLenghtPassword || arrayRecipientNumber.Length > MaxLenghtPassword)
                {
                    Output.InformMistake();
                }
            }
            while (arrayRecipientNumber.Length < MaxLenghtPassword || arrayRecipientNumber.Length > MaxLenghtPassword);
        }

        public void CheckTypeCard()
        {
            if (typeOfCard == (int)TypeCards.Debit)
            {
                SomeTypeOfCards = BankStorage.DebitCards;
            }
            else if (typeOfCard == (int)TypeCards.Credit)
            {
                SomeTypeOfCards = BankStorage.CreditCards;
            }
        }

        public void CheckCredit()
        {
            for (int counter = 0; counter < BankStorage.AccountsScore.Length; counter++)
            {
                Credit = BankStorage.AccountsScore[counter] < 0;

                if (Credit == true)
                {
                    Clear();

                    WriteLine("You  have  unsecured loan on your accounts. ");

                    break;
                }
            }
        }

        public void CheckRightAccount()
        {
            for (int counter = 0; counter < SomeTypeOfCards.Length; counter++)
            {
                RightNumberOfAccount = numberCard == counter;

                if (RightNumberOfAccount == true)
                {
                    break;
                }
            }

            if (RightNumberOfAccount == false)
            {
                WriteLine("Wrong number of card");
            }
        }

        public void CheckNumberAccountForTrans()
        {
            if (SomeTypeOfCards == BankStorage.CreditCards)
            {
                for (int counter = 0; counter < SomeTypeOfCards.Length; counter++)
                {
                    if (accountForTransit != SomeTypeOfCards[counter] - ConvertToArrayStyle)
                    {
                        WrongNumberOfAccount = true;

                        Output.InformMistake();
                    }
                }
            }
        }

        public void CheckNegativeBallance()
        {
            if (Bank.money > BankStorage.AccountsScore[Bank.SomeTypeOfCards[Bank.numberCard]] && Bank.SomeTypeOfCards == BankStorage.DebitCards)
            {
                NegativeBallance = true;

                Clear();

                WriteLine("You dont have enough money on account.");
            }
        }
    }
}