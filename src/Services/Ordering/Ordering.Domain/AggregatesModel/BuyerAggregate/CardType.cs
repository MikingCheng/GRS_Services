using System;
using System.Collections.Generic;
using System.Text;
using WWGRS.Service.Ordering.Domain.SeedWork;

namespace WWGRS.Service.Ordering.Domain.AggregatesModel.BuyerAggregate
{
    public class CardType : Enumeration
    {
        public static CardType Amex = new CardType(1, "Amex");
        public static CardType Visa = new CardType(2, "Visa");
        public static CardType MasterCard = new CardType(3, "MasterCard");

        public CardType(int id, string name)
            : base(id, name)
        {
        }
    }
}
