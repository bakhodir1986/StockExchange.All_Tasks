using System;
using System.Collections.Generic;
using System.Text;

namespace StockExchange.Task1
{
    public interface IStockExchangeMediator
    {
        bool Notify(StockObject stockObject);
    }
}
