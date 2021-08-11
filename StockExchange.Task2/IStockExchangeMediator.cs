using System;
using System.Collections.Generic;
using System.Text;

namespace StockExchange.Task2
{
    public interface IStockExchangeMediator
    {
        bool Notify(StockObject stockObject);
    }
}
