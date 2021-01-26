using System.Threading;
using static System.Console;

namespace ITBank_2._0
{
    public static class Output
    {
        public static void InformMistake()
        {
            WriteLine("You have mistake, write correctly.");
        }

        public static void ShowCardFunctions()
        {
            WriteLine("What you want to do?" +
                     "\n1)Add money to account." +
                     "\n2)Get Money from account." +
                     "\n3)Look score." +
                     "\n4)Transition money.");
        }

        public static void ShowTypeTransitions()
        {
            WriteLine("Where are you want transit your money" +
                "\n1)Your accounts." +
                "\n2)Other accounts.");
        }

        public static void ShowNewOperationOptions()
        {
            WriteLine("Would you like to do another surgery?" +
               "\n1)Enter." +
               "\n2)Esc.");
        }

        public static void ShowTypeOfCard()
        {
            WriteLine("Choose card " +
             "\n1)Debit." +
             "\n2)Kredit.");
        }

        public static void ShowReconnectionOptions()
        {
            WriteLine("Do you want create card?\n" +
                      "1)Enter\n" +
                      "2)Espace");
        }

        public static void LoadingInform()
        {
            WriteLine("Loading...");

            Thread.Sleep(2500);

            Clear();

            WriteLine("Operation was a success.");
        }
    }
}
