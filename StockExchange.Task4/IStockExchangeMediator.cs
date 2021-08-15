using System;
using System.Collections.Generic;
using System.Text;

namespace StockExchange.Task4
{
    public interface IStockExchangeMediator
    {
        void Subcribe(IPlayer player);

        void UnSubcribe(IPlayer player);

        bool Notify(StockObject stockObject);

        void NotifyDeal(IPlayer player, int NumberOfShares);

        delegate void NotifyDealDelagate(int soldShares, int boughtShares);

        event NotifyDealDelagate notifyDealEvent;
    }
}
