namespace SpartaTextRpg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Plyaer player = new Plyaer();
            player.addItme();

            while (true)
            {
                player.pintMain();
                

            }    
        }
    }
}