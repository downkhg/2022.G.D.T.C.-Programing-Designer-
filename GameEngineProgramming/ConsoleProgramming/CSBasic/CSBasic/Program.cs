using System;
using System.Collections.Generic;

namespace CSBasic
{
    class Program
    {
        //Ctrl+F5: 디버거없이 빌드 및 실행
        static void Main(string[] args)//프로그램이 처음 실행했을때 가장 먼저 호출하는 함수
        {
            Console.WriteLine("Hello World!?!?");
            Console.WriteLine("Add:" + Add(30, 20));
            //ValMain();//2. 함수의 호출: 정의된 함수를 여기에서 사용하도록 하는 것.
            //PlayerAttackMain();
            //BattleMain();
            //ClassBattleMain();
            SelectStageMain();
        }
        //변수: 데이터를 담는 상자
        static int Add(int a, int b)//30, 20
        {
            int c = a + b; //50 = 30 + 20
            return c;//50
        }
        //1. 함수선언
        static void ValMain()
        {
            //3. 함수의 정의
            Console.WriteLine("ValMain");
        }
        //플레이어가 몬스터를 공격한다.
        //공격: (플레이어 공격력)를 (몬스터 hp)를 감소시킨다.
        //자학: (플레이어 공격력)를 (플레이어 hp)를 감소시킨다. X
        static void PlayerAttackMain()
        {
            int nPlayerAttack = 10;
            int nMonsterHP = 100;

            while (nMonsterHP > 0)//죽지않았을때 -> 살아있을때
            {
                nMonsterHP = nMonsterHP - nPlayerAttack;

                Console.WriteLine("nMonsterHP:" + nMonsterHP);
                Console.WriteLine("nPlayerAttack:" + nPlayerAttack);
            }
        }
        //플레이어가 몬스터를 공격한다.
        //몬스터가 플레이어를 반격한다.
        static void BattleMain()
        {
            int nPlayerHP = 100;
            int nPlayerAttack = 10;

            int nMonsterHP = 100;
            int nMonsterAttack = 10;

            while (nMonsterHP > 0 || nPlayerHP > 0)//죽지않았을때 -> 살아있을때
            {
                Console.WriteLine("Player Turn");
                if (nPlayerHP > 0)//플레이어가 공격
                {
                    nMonsterHP = nMonsterHP - nPlayerAttack;

                    Console.WriteLine("nMonsterHP:" + nMonsterHP);
                    Console.WriteLine("nPlayerAttack:" + nPlayerAttack);
                }
                else break;
                Console.WriteLine("Monster Turn");
                if (nMonsterHP > 0)
                {
                    nPlayerHP = nPlayerHP - nMonsterAttack;

                    Console.WriteLine("nPlayerHP:" + nPlayerHP);
                    Console.WriteLine("nMonsterAttack:" + nMonsterAttack);
                }
                else break;
            }
        }

        class Player
        {
            string strName;
            int nAttack;
            int nHp;

            public Player(string name, int atk, int hp)
            {
                strName = name;
                nAttack = atk;
                nHp = hp;
            }

            public void Attack(Player target)
            {
                target.nHp -= nAttack;
            }

            public bool Death()
            {
                if (nHp <= 0)
                    return true;
                else
                    return false;
            }

            public void Show()
            {
                Console.WriteLine("Name:" + strName);
                Console.WriteLine("HP:" + nHp);
                Console.WriteLine("Attack:" + nAttack);
            }
        }

        static void ClassBattleMain()
        {
            Player player = new Player("player",10,100);
            Player monster =  new Player("monster",10,20);

            player.Show();
            monster.Show();

            while (!player.Death() && !monster.Death())//죽지않았을때 -> 살아있을때
            {
                Console.WriteLine("Player Turn");
                if (player.Death() == false)//플레이어가 공격
                {
                    player.Attack(monster);

                    monster.Show();
                }
                else break;
                Console.WriteLine("Monster Turn");
                if (monster.Death() == false)//플레이어가 공격
                {
                    monster.Attack(player);

                    player.Show();
                }
                else break;
            }
        }

        static void ClassBattle(Player player, Player monster)
        {
            player.Show();
            monster.Show();

            while (!player.Death() && !monster.Death())//죽지않았을때 -> 살아있을때
            {
                Console.WriteLine("Player Turn");
                if (player.Death() == false)//플레이어가 공격
                {
                    player.Attack(monster);

                    monster.Show();
                }
                else break;
                Console.WriteLine("Monster Turn");
                if (monster.Death() == false)//플레이어가 공격
                {
                    monster.Attack(player);

                    player.Show();
                }
                else break;
            }
        }

        static void SelectStageMain()
        {
            string strInput = "";
            Player player = new Player("player", 10, 100);
            Player monster = new Player("monster", 10, 20);

            List<Player> listMonsters = new List<Player>();
            listMonsters.Add(new Player("slime", 10, 20));
            listMonsters.Add(new Player("skeleton", 20, 50));

            while (strInput != "exit")
            {
                Console.WriteLine("어디로 갈지 입력해주세요.");
                strInput = Console.ReadLine();
                switch(strInput)
                {
                    case "마을":
                        Console.WriteLine("마을 입니다.");
                        break;
                    case "필드":
                        ClassBattle(player,listMonsters[1]);
                        break;
                }
            }
        }
    }
}
