using System;
using System.Collections.Generic;
using System.Text;

namespace StockExchange.Task4
{
    public class StockObject
    {
        public IPlayer Player { get; set; }

        public string Name { get; set; }

        public int NumberOfShares { get; set; }

        public string EventType { get; set; }
    }
}
