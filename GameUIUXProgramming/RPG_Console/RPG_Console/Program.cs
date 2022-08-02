using System;

namespace RPG_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager cGameManager = new GameManager();
            bool isExit = true;
            cGameManager.Init();

            while(isExit)
            {
                cGameManager.Update();
            }
        }
    }
}
