using System;
using System.Collections.Generic;
using System.Text;

namespace CSBasic
{
    class Trainer 
    {
        List<Pokemon> pokemons = new List<Pokemon>();

        public void Catch(Pokemon pokemon)
        {
            pokemons.Add(pokemon);
        }
        public Pokemon Throw(string name)
        {
            return pokemons.Find(pokemon => { return pokemon.Name == name; });
        }

        public void PokemonListShow()
        {
            Console.WriteLine("######## PokemonList ########");
            foreach (Pokemon pokemon in pokemons)
            {
                Console.WriteLine("Pokemon:" + pokemon.Name);
            }
        }
    }
    class Pokemon
    {
        string strName;
        int nAttack;
        int nHp;

        public string Name { get { return strName; } }

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
            Console.WriteLine("Name:" + strName);
            Console.WriteLine("HP:" + nHp);
            Console.WriteLine("Attack:" + nAttack);
        }
    }
    class PokemonGame
    {
        static Pokemon Battle(Pokemon player, Pokemon monster)
        {
            player.Show();
            monster.Show();

            while (!player.Death() && !monster.Death())//죽지않았을때 -> 살아있을때
            {
                Console.WriteLine("My Pokemon Turn");
                if (player.Death() == false)//플레이어가 공격
                {
                    player.Attack(monster);
                    monster.Show();
                }
                else
                {
                    Console.WriteLine("My Pokemon Turn! :" + player.Name);
                    return player;
                }
                Console.WriteLine("Wild Pokemon Turn");
                if (monster.Death() == false)//플레이어가 공격
                {
                    monster.Attack(player);
                    player.Show();
                }
                else
                {
                    Console.WriteLine("Wild Pokemon Win! :" + player.Name);
                    return monster;
                }
            }

            return null;
        }

        public static void Game()
        {
            Trainer trainer = new Trainer();
            trainer.Catch(new Pokemon("picachu", 10, 50));
            trainer.PokemonListShow();
            List<Pokemon> wildPokemons = new List<Pokemon>();

            wildPokemons.Add(new Pokemon("hee-jung", 10, 20));
            wildPokemons.Add(new Pokemon("sang-hyeon", 10, 20));
            wildPokemons.Add(new Pokemon("ye-lin", 10, 20));
            wildPokemons.Add(new Pokemon("ji-hyeon", 10, 20));

            while(true)
            {
                Console.Write("Select Filed(sea,forest,mountin,desert):");
                string strInput = Console.ReadLine();
                Pokemon wildPokemon = null;
               

                switch(strInput)
                {
                    case "sea":
                        wildPokemon = wildPokemons.Find(pokemon => { return pokemon.Name == "sang-hyeon"; });
                        break;
                    case "forest":
                        wildPokemon = wildPokemons.Find(pokemon => { return pokemon.Name == "hee-jung"; });
                        break;
                    case "mountin":
                        wildPokemon = wildPokemons.Find(pokemon => { return pokemon.Name == "ye-lin"; });
                        break;
                    case "desert":
                        wildPokemon = wildPokemons.Find(pokemon => { return pokemon.Name == "ji-hyeon"; });
                        break;
                }

                trainer.PokemonListShow();
                Console.Write("Select Pokemon:");
                strInput = Console.ReadLine();

                Pokemon myPokemon = trainer.Throw(strInput);
                Pokemon catchPokeom = Battle(myPokemon, wildPokemon);

                if(catchPokeom != null)
                    trainer.Catch(catchPokeom);
            }
        }
    }
}
