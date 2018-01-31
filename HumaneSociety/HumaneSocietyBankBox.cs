using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class HumaneSocietyBankBox
    {
        public List<Money> safe;
        public HumaneSocietyBankBox()
        {
            safe = new List<Money>();
        }
        
        public void AcceptMoney(int price)
        {
            Money money = new Money();
            for (int i = 0; i < price; i++)
            {
                safe.Add(money);
            }
        }
    }
}
