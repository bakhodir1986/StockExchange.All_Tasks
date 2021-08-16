using System;
using System.Collections.Generic;
using System.Text;

namespace StockExchange.Task4
{
    public interface IStockExchangeMediator
    {
        void Subcribe(IPlayer player);

        void UnSubcribe(IPlayer player);

        bool Notify(StockObject firstPlayersStockObject);

        void NotifyDeal(IPlayer player, int numberOfShares);

    }
}
