using ncore.m3decsharp.levels;


namespace ncore.m3decsharp
{
    class MainClass
    {
        static void Main(string[] args)
        {
            using var game = new Level1(); 
            game.Run();
        }
    }

}
