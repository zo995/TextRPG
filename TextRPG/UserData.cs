
namespace TextRPG
{
    internal class UserData
    {
        public static int HP = 100, userPower, killUnit=0, swordID=0;
        public static string nameHero="Некто";
        public static int PowerBust()
        {
            switch (swordID)
            {
                case 0:
                    userPower= 0;
                    break;
                case 2:
                    userPower= 3;
                    break;
            }
            return userPower;
        }
    }
}