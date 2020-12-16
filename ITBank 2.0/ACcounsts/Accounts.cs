using BankAccount;
namespace BankAccounts
{
    public class Accounts : Aсcount
    {
        public Aсcount[] accounts;
        public  void CreatAccuonts(int numberCard)
        {
            accounts = new Aсcount[numberCard];
            for (int i = 0; i < numberCard; i++)
            {
                accounts[i] = new Aсcount();
            }
        }
    }
}
