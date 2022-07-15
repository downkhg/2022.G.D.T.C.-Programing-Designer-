using System;
using System.Collections.Generic;
using System.Text;

namespace CSBasic
{
    class Trainer 
    {
        List<Pokemon> pokemons = new List<Pokemon>();
        string strName;
        public string Name { get { return strName; } }
        public void Catch(Pokemon pokemon)
        {
            pokemons.Add(pokemon);
        }
        public Pokemon Throw(string name)
        {
            Pokemon throwPokemon = pokemons.Find(pokemon => { return pokemon.Name == name; });
            pokemons.Remove(throwPokemon);
            return throwPokemon;
        }
        public void PokemonListShow()
        {
            Console.WriteLine("######## 포켓몬가방 ########");
            foreach (Pokemon pokemon in pokemons)
            {
                Console.WriteLine(pokemon.Name);
            }
        }
    }
    class Pokemon
    {
        string strName;
        int nAttack;
        int nHp;
        public string Name { get { return strName; } set { strName = value; } }
        public Pokemon(string name, int atk, int hp)
        {
            strName = name;
            nAttack = atk;
            nHp = hp;
        }
        public void Attack(Pokemon target)
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
            Console.WriteLine("이름:" + strName);
            Console.WriteLine("체력:" + nHp);
            Console.WriteLine("공격력:" + nAttack);
        }
    }
    class PokemonGame
    {
        static Pokemon Battle(Pokemon player, Pokemon monster)
        {
            player.Show();
            monster.Show();

            while (true)//죽지않았을때 -> 살아있을때
            {
                Console.WriteLine("###### 내 턴 #######");
                if (player.Death() == false)//플레이어가 공격
                {
                    Console.WriteLine(string.Format("{0} is Attack {1}", player.Name, monster.Name));
                    player.Attack(monster);
                    monster.Show();
                }
                else
                {
                    Console.WriteLine(player.Name + "가 쓰려졌다!");
                    return null;
                }
                Console.WriteLine("###### 상대 턴 ######");
                if (monster.Death() == false)//플레이어가 공격
                {
                    Console.WriteLine(string.Format("{0} is Attack {1}", monster.Name, player.Name));
                    monster.Attack(player);
                    player.Show();
                }
                else
                {
                    Console.WriteLine(player.Name + "가 이겼다!");
                    return monster;
                }
            }

            return null;
        }

        public static void Game()
        {
            Trainer trainer = new Trainer();
            trainer.Catch(new Pokemon("피카츄", 10, 50));
            trainer.PokemonListShow();
            List<Pokemon> wildPokemons = new List<Pokemon>();

            wildPokemons.Add(new Pokemon("잉어킹", 10, 20));
            wildPokemons.Add(new Pokemon("우츠보트", 10, 20));
            wildPokemons.Add(new Pokemon("피존", 10, 20));
            wildPokemons.Add(new Pokemon("모래두지", 10, 20));

            while(true)
            {
                Console.Write("필드를 선택하세요!(바다,숲,산,사막):");
                string strInput = Console.ReadLine();
                Pokemon wildPokemon = null;
               
                switch(strInput)
                {
                    case "바다":
                        wildPokemon = wildPokemons.Find(pokemon => { return pokemon.Name == "잉어킹"; });
                        break;
                    case "숲":
                        wildPokemon = wildPokemons.Find(pokemon => { return pokemon.Name == "우츠보트"; });
                        break;
                    case "산":
                        wildPokemon = wildPokemons.Find(pokemon => { return pokemon.Name == "피존"; });
                        break;
                    case "사막":
                        wildPokemon = wildPokemons.Find(pokemon => { return pokemon.Name == "모래두지"; });
                        break;
                    default:
                        Console.WriteLine(strInput+"는 존재하지않는 장소입니다.");
                        break;
                }

                if (wildPokemon != null)
                {
                    trainer.PokemonListShow();
                    Console.Write("포켓몬가방에 포켓몬을 선택하세요!:");
                    strInput = Console.ReadLine();

                    Pokemon myPokemon = trainer.Throw(strInput);
                    if (myPokemon != null)
                    {
                        Pokemon catchPokeom = Battle(myPokemon, wildPokemon);

                        if (catchPokeom != null)
                        {
                            Console.WriteLine(catchPokeom.Name + "을 획득했다!");
                            trainer.Catch(catchPokeom);
                        }

                        trainer.Catch(myPokemon);
                    }
                    else
                        Console.WriteLine(strInput + "가 가방에 없습니다!");
                }
            }
        }
    }
}
