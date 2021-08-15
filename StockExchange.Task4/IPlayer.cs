using System;
using System.Collections.Generic;
using System.Text;

namespace StockExchange.Task4
{
    public interface IPlayer
    {
        int SoldShares { get; }

        int BoughtShares { get; }

        bool SellOffer(string stockName, int numberOfShares);

        bool BuyOffer(string stockName, int numberOfShares);

        void Update(int soldShares, int boughtShares);
    }
}
