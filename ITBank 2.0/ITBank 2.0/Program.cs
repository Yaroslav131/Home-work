using static System.Console;

namespace ITBank_2._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bank bank = new Bank();
            Card card = new Card();

            WriteLine("Wellcom to the ITBank.");

            bank.CreateAccounts();

            do
            {
                Clear();

                bank.LinkCards();

                if (BankStorage.DebitCards.Length == 0 && BankStorage.CreditCards.Length == 0)
                {
                    WriteLine("You don't have card in this bank");

                    bank.RecreateCard();
                }
            }
            while (Bank.ReconnectionCard);

            if (!(BankStorage.DebitCards.Length == 0 && BankStorage.CreditCards.Length == 0))
            {
                do
                {
                    Clear();

                    bank.ChooseCardFunction();

                    switch (Bank.NumberOfCardFunction)
                    {
                        case (int)Bank.CardFunctions.AddMoney:

                            Clear();

                            bank.ChooseCard();

                            Clear();

                            bank.SetSum();

                            Clear();

                            if (Bank.RightNumberOfAccount)
                            {
                                card.AddMoney();
                            }

                            break;

                        case (int)Bank.CardFunctions.GetMoney:

                            Clear();

                            bank.ChooseCard();

                            Clear();

                            if (Bank.RightNumberOfAccount && !Bank.Credit)
                            {
                                bank.SetSum();

                                if (!Bank.NegativeBallance)
                                {
                                    card.GetMoney();
                                }
                            }

                            break;

                        case (int)Bank.CardFunctions.ShowMoney:

                            Clear();

                            bank.ChooseCard();

                            Clear();

                            if (Bank.RightNumberOfAccount)
                            {
                                card.ShowMoney();
                            }

                            break;

                        case (int)Bank.CardFunctions.TransitMoney:

                            Clear();

                            bank.ChooseTypeTransitoin();

                            Clear();

                            bank.ChooseCard();

                            Clear();

                            if (Bank.RightNumberOfAccount && !Bank.Credit)
                            {
                                bank.SetSum();

                                if (Bank.TypeOfTransition == (int)Bank.TypeTransitions.TransitMoney && !Bank.NegativeBallance)
                                {
                                    Clear();

                                    bank.ChooseAccountForTransit();

                                    if (!Bank.WrongNumberOfAccount)
                                    {
                                        card.TransitMoney();
                                    }
                                }
                                else if (Bank.TypeOfTransition == (int)Bank.TypeTransitions.TransitMoneyOhterAccount && !Bank.NegativeBallance)
                                {
                                    Clear();

                                    bank.GetRecipientData();

                                    card.TransitMoneyOhterAccount();
                                }
                            }

                            break;

                        default:

                            Clear();

                            WriteLine("We don't have this operatioin,try again.");

                            break;
                    }

                    bank.StartNewOperation();
                }
                while (Bank.NumberOfNewOperationOptions == (int)Bank.NewOperationOptions.Yes);

                Clear();
            }
        }
    }
}