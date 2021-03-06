namespace StockExchange.Task1
{
    public class StockPlayersFactory
    {
        public Players CreatePlayers()
        {
            var meditor = new StockExchangeController();

            return new Players
            {
                RedSocks = new RedSocks(meditor),
                Blossomers = new Blossomers(meditor)
            };
        }
    }
}
