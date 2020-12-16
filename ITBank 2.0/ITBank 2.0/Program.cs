using BankAccounts;
using BankCards;
using BankFunctions;
using OutputLine;
using static System.Console;

namespace ITBank_2._0
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CardFunctions card = new CardFunctions();
            BankFunction bankFunction = new BankFunction();
            Accounts accounts = new Accounts();

            WriteLine("Wellcom to the ITBank.");

            bankFunction.CreatAccuonts();

            Clear();

            bankFunction.LinkCards();

            do
            {
                Clear();

                Output.ShowFunctions();

                bankFunction.ChooseFunction();

                switch (BankFunction.FunctionNumber)
                {
                    case (int)BankFunction.CardFunctions.AddMoney:

                        Clear();

                        card.ChooseCard();

                        Clear();

                        card.AddMoney();

                        bankFunction.ChooreSurgery();

                        break;

                    case (int)BankFunction.CardFunctions.GetMoney:

                        Clear();

                        card.ChooseCard();

                        Clear();

                        card.GetMoney();

                        bankFunction.ChooreSurgery();

                        break;

                    case (int)BankFunction.CardFunctions.ShowMoney:

                        Clear();

                        card.ChooseCard();

                        Clear();

                        card.ShowMoney();

                        bankFunction.ChooreSurgery();

                        break;

                    case (int)BankFunction.CardFunctions.TransitMoney:

                        Clear();

                        bankFunction.ChooseTypeTransitoin();

                        Clear();

                        card.ChooseCard();

                        if (BankFunction.TypeTransition == (int)BankFunction.TypeTransit.TransitMoney)
                        {
                            card.TransitMoney();
                        }
                        else if (BankFunction.TypeTransition == (int)BankFunction.TypeTransit.TransitMoneyOhterAccount)
                        {
                            card.TransitMoneyOhterAccount();
                        }

                        bankFunction.ChooreSurgery();

                        break;

                    default:

                        Clear();

                        WriteLine("We don't have this operatioin,try again.");

                        bankFunction.ChooreSurgery();

                        break;
                }
            }
            while (BankFunction.SurgeryConditon == (int)BankFunction.SurgeryConditons.Yes);
        }
    }
}


