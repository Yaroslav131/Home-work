using System;
using  BankAccounts;
using System.Threading;
using static System.Console;
namespace Cards
{
    public class Card : Accounts
    {
        internal double addMoney;
        public double GetMoney { get; set; }
        public double TransitionMoney { get; set; }
        public int UserAccountTransition { get; set; }

        public string RecipientName { get; set; }
        public string RecipientSurname { get; set; }
        public string RecipientLastname { get; set; }
        public string RecipientAccountNumber { get; set; }
        public int[] ArrayRecipientNumber { get; set; }
        public bool Link { get; set; }
       
        public void CreateCard()
        {

            WriteLine("Choose numbers of acounts, what you want to create. ");
            while (!int.TryParse(ReadLine(), out ChooseCond))
            {
                WriteLine("Write correctly,it's not number");
            }
            card.CreatAccuonts(ChooseCond);

            Clear();

            WriteLine("Choose how mach you want have debit card. ");
            while (!int.TryParse(ReadLine(), out ChooseCond))
            {
                WriteLine("Write correctly,it's not number");
            }
            LinkCardD(ChoooseCond);

            Clear();

            WriteLine("Choose how mach you want have credit card. ");
            while (!int.TryParse(ReadLine(), out ChoooseCond))
            {
                WriteLine("Write correctly,it's not number");
            }

            LinkCardK(ChoooseCond);




        }

            
        public void AddMoney(double add, int idCard, int cond)
        {
            if (cond == 1)
            {
                if (idCard > ArrCardD.Length || idCard < ArrCardD[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    accounts[ArrCardD[idCard - 1]].Money += add;
                    WriteLine("Loading...");
                    Thread.Sleep(2500);
                    Clear();
                    WriteLine("Operation was a success.");
                }
            }
            else
            {
                if (idCard > ArrCardK.Length || idCard < ArrCardK[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    accounts[ArrCardK[idCard - 1]].Money += add;
                    WriteLine("Loading...");
                    Thread.Sleep(2500);
                    Clear();
                    WriteLine("Operation was a success.");
                }
            }
        }
        public void GetMoney(double get, int idCard, int cond)
        {
            Credit = false;
            for (int i = 0; i < accounts.Length; i++)
            {
                Credit = accounts[i].Money < 0;
                if (Credit == true)
                {
                    break;
                }
            }
            if (cond == 2)
            {
                if (idCard > ArrCardK.Length || idCard < ArrCardK[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    if (Credit)
                    {
                        WriteLine("You  have  unsecured loan on your accounts. ");
                    }
                    else
                    {
                        accounts[ArrCardK[idCard - 1]].Money -= get;
                        WriteLine("Loading...");
                        Thread.Sleep(2500);
                        Clear();
                        WriteLine("Operation was a success.");
                    }
                }
            }
            else if (cond == 1)
            {
                if (idCard > ArrCardD.Length || idCard < ArrCardD[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    if (accounts[ArrCardD[idCard - 1]].Money < get)
                    {
                        WriteLine("You dont have enough money on account.  ");
                    }
                    else
                    {
                        accounts[ArrCardD[idCard - 1]].Money -= get;
                        WriteLine("Loading...");
                        Thread.Sleep(2500);
                        Clear();
                        WriteLine("Operation was a success.");
                    }
                }
            }
        }
        public void ShowMoney(int idCard, int cond)
        {
            WriteLine("Loading...");
            Thread.Sleep(2500);
            Clear();
            WriteLine("Operation was a success.");
            if (cond == 1)
            {
                if (idCard > ArrCardD.Length || idCard < ArrCardD[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    WriteLine($"In Your accont { accounts[ArrCardD[idCard - 1]].Money }$.");
                }
            }
            else
            {
                if (idCard > ArrCardK.Length || idCard < ArrCardK[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    WriteLine($"In Your accont { accounts[ArrCardK[idCard - 1]].Money }$.");
                }
            }
        }
        public void TransitMoney(double trans, int idCard, int numAcc, int cond)
        {
            bool Credit = false;
            for (int i = 0; i < accounts.Length; i++)
            {
                Credit = accounts[i].Money < 0;
            }
            if (cond == 1)
            {
                if (idCard > ArrCardD.Length || idCard < ArrCardD[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    if (accounts[ArrCardD[idCard - 1]].Money < trans)
                    {
                        WriteLine("You dont have enough money on account.  ");
                    }
                    else
                    {
                        accounts[ArrCardD[idCard - 1]].Money -= trans;
                        accounts[numAcc - 1].Money += trans;
                        WriteLine("Loading...");
                        Thread.Sleep(2500);
                        Clear();
                        WriteLine("Operation was a success.");
                    }
                }
            }
            else if (cond == 2)
            {
                if (idCard > ArrCardK.Length || idCard < ArrCardK[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    if (Credit)
                    {
                        WriteLine("You  have  unsecured loan on your accounts. ");
                    }
                    else
                    {
                        for (int i = 0; i < ArrCardD.Length; i++)
                        {
                            if (Link = numAcc - 1 == ArrCardD[i])
                            {
                                Clear();
                                WriteLine("Transition beetwen debit and Credit card is prohibited. ");
                                break;
                            }
                        }
                        if (Link == false)
                        {
                            Clear();
                            accounts[ArrCardK[idCard - 1]].Money -= trans;
                            accounts[numAcc - 1].Money += trans;
                            WriteLine("Loading...");
                            Thread.Sleep(2500);
                            Clear();
                            WriteLine("Operation was a success.");
                        }
                    }
                }
            }
        }
        public void TransitMoney(double trans, int idCard, int cond)
        {
            Credit = false;
            for (int i = 0; i < accounts.Length; i++)
            {
                Credit = accounts[i].Money < 0;
            }
            if (cond == 1)
            {
                if (idCard > ArrCardD.Length || idCard < ArrCardD[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    if (accounts[idCard - 1].Money < trans)
                    {
                        WriteLine("You dont have enough money on account.  ");
                    }
                    else
                    {
                        accounts[ArrCardD[idCard - 1]].Money -= trans;
                        WriteLine("Loading...");
                        Thread.Sleep(2500);
                        Clear();
                        WriteLine("Operation was a success.");

                    }
                }
            }
            else if (cond == 2)
            {
                if (idCard > ArrCardK.Length || idCard < ArrCardK[0])
                {
                    WriteLine("Wrong number of card");
                }
                else
                {
                    if (Credit)
                    {
                        WriteLine("Loading...");
                        Thread.Sleep(2500);
                        Clear();
                        WriteLine("You dont have enough money on account unsecured loan on your accounts. ");
                    }
                    else
                    {
                        accounts[ArrCardK[idCard - 1]].Money -= trans;
                        WriteLine("Loading...");
                        Thread.Sleep(2500);
                        Clear();
                        WriteLine("Operation was a success.");
                    }
                }
            }
        }
    }
}
