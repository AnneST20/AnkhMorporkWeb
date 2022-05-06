namespace AnkhMorporkWeb.Repository
{
    public static class GuildInfo
    {
        public static string AssassinInfo()
        {
            return "Someone hired assassins to kill you.\n" +
                "To avoid death,\n" +
                "you can re-sign a contract with the assassins";
        }

        public static string AssassinSucces(decimal reward)
        {
            return $"You successed in resigning the contract. You spent {reward} AM$";
        }

        public static string AssassinFail()
        {
            return "Assassin killed you";
        }

        public static string BeggarsInfo(string type, decimal money, bool beer)
        {
            string wantBeer = beer ? "and 1 beer" : "";
            return $"There're {type}.\n They want {money} AM$" + wantBeer;
        }
        public static string BeggarSuccess(string type, decimal fee, bool beer)
        {
            int beerCount = beer ? 1 : 0;
            return $"You gave {fee} AM$ and {beerCount} beer to {type}";
        }

        public static string BeggarFail()
        {
            return "You were persecuted for the rest of you life";
        }

        public static string FoolInfo(string type, decimal money)
        {
            return $"There's a {type}.\n " +
                $"He asks you for help.\n " +
                $"If you agree, he will give you {money} AM$";
        }

        public static string FoolSucces(string type, decimal reward)
        {
            return $"You received {reward}$ AM from {type}";
        }

        public static string FoolFail()
        {
            return "A fool said goodbye to you and went away";
        }

        public static string ThiefInfo()
        {
            return "The thief put a knife to your throat\n" +
                "and demands 10 AM$";
        }

        public static string ThiefSucces(decimal reward)
        {
            return $"You gave {reward} AM$ but you are still alive!";
        }

        public static string ThiefFail()
        {
            return "The thief cut your throat";
        }

        public static string TavernaInfo()
        {
            return "You can buy 1 beer for 2 AM$";
        }

        public static string TavernaSuccess()
        {
            return "You bought 1 beer";
        }

        public static string TavernaFail()
        {
            return "You left taverna";
        }
    }
}