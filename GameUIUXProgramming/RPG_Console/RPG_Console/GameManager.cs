using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Console
{
    public class GameManager
    {
        public enum eStage
        {
            CREATE,
            TOWN,
            INVENTORY,
            STORE,
            FILED, //필드선택
            BATTLE, //전투지역
            GAMEOVER,
            THEEND
        }
        public enum eMonster { SLIME, SKELTON, BOSS, MAX };

        ItemManager m_cItemManager;
        Player m_cPlayer;
        Player m_cStore;
        Player m_cMonster;

        eMonster m_eMonsterIdx;
        eStage m_eStage = eStage.CREATE;

        static GameManager m_cInstance = null;

        public eStage Stage {
            get { return m_eStage;}
        }
        public Player Player
        {
            get { return m_cPlayer; }
        }
        public Player Monster
        {
            get { return m_cMonster; }
        }

        public GameManager()
        {
            m_cInstance = this;
        }

        public static GameManager GetInstance()
        {
            return m_cInstance;
        }

        public void Init()
        {
            m_cItemManager = new ItemManager();
            m_cStore = new Player("Store");

            m_cStore.SetInvetory(m_cItemManager.GetItem(ItemManager.eItem.HPPotion));
            m_cStore.SetInvetory(m_cItemManager.GetItem(ItemManager.eItem.MPPotion));
            m_cStore.SetInvetory(m_cItemManager.GetItem(ItemManager.eItem.Stone));
            m_cStore.SetInvetory(m_cItemManager.GetItem(ItemManager.eItem.Boom));

            m_cMonster = new Player("Slime", 100, 100, 10, 0, 0, 100);
            m_cMonster.SetInvetory(m_cItemManager.GetItem(ItemManager.eItem.WoodSword));
            m_cMonster.SetInvetory(m_cItemManager.GetItem(ItemManager.eItem.WoodArmor));
            m_cMonster.SetInvetory(m_cItemManager.GetItem(ItemManager.eItem.WoodRing));
            m_cPlayer = new Player("Player", 100, 100, 10, 10, 10, 0, 9999999);
            m_cPlayer.SetInvetory(m_cItemManager.GetItem(ItemManager.eItem.HPPotion));
            m_cPlayer.SetInvetory(m_cItemManager.GetItem(ItemManager.eItem.MPPotion));
            m_cPlayer.SetInvetory(m_cItemManager.GetItem(ItemManager.eItem.Stone));
            m_cPlayer.SetInvetory(m_cItemManager.GetItem(ItemManager.eItem.Boom));
        }

        public void Update()
        {
            switch (m_eStage)
            {
                case eStage.CREATE:
                    EventCreate();
                    break;
                case eStage.TOWN:
                    EventTown();
                    break;
                case eStage.INVENTORY:
                    EventInvetory();
                    break;
                case eStage.STORE:
                    EventStore();
                    break;
                case eStage.FILED:
                    EventFiled();
                    break;
                case eStage.BATTLE:
                    EventBattle();
                    break;
                case eStage.GAMEOVER:
                    Console.WriteLine("Game Over!");
                    break;
                case eStage.THEEND:
                    Console.WriteLine("The End!");
                    break;
            }
        }

        public void EventCreate()
        {
            Console.WriteLine("케릭터이름을 입력하세요:");
            string strName = Console.ReadLine();
            m_cPlayer = new Player(strName, 100, 100, 10, 10, 10, 0, 9999999);
            m_eStage = eStage.TOWN;
        }

        public void EventInvetory()
        {
            m_cPlayer.ShowInevtory();
            Console.WriteLine("어떻게 하시겠습니까? 1:장착, 2:해재 etc:마을");
            int nSelect = int.Parse(Console.ReadLine());
            if (nSelect == 1)
            {
                nSelect = int.Parse(Console.ReadLine());
                Item cItem = m_cPlayer.GetInvetory(nSelect);
                m_cPlayer.SetEquemnt(cItem);
            }
            else if (nSelect == 2)
            {
                nSelect = int.Parse(Console.ReadLine());
                Item cItem = m_cPlayer.GetInvetory(nSelect);
                for (int i = 0; i < (int)Player.eEqumentKind.MAX; i++)
                    Console.Write(String.Format("{0}:{1},", i, (Player.eEqumentKind)i));
                m_cPlayer.ReleaseEquemnt((Player.eEqumentKind)nSelect);
            }
            else
            {
                m_eStage = eStage.TOWN;
            }
        }

        public void EventStore()
        {
            Console.WriteLine("어떻게 하시겠습니까? 1:구매, 2:판매 etc:마을");
            int nSelect = int.Parse(Console.ReadLine());
            if (nSelect == 1)
            {
                m_cStore.ShowInevtory();
                nSelect = int.Parse(Console.ReadLine());
                m_cPlayer.Buy(nSelect, m_cStore);
            }
            else if (nSelect == 2)
            {
                m_cPlayer.ShowInevtory();
                nSelect = int.Parse(Console.ReadLine());
                m_cPlayer.Sell(nSelect);
            }
            else
            {
                m_eStage = eStage.TOWN;
            }
        }

        public void EventTown()
        {
            m_cPlayer.Recovery();
            m_cPlayer.ShowInevtory();
            Console.Write("마을 입니다. 어디로 가시겠습니까? ");
            for (int i = (int)eStage.TOWN + 1; i < (int)eStage.BATTLE; i++)
                Console.Write(String.Format("{0}:{1},", i, (eStage)i));
            m_eStage = (eStage)int.Parse(Console.ReadLine());
        }

        public void EventFiled()
        {
            Console.Write("필드을 선택하세요! ");
            for (int i = (int)eMonster.SLIME; i < (int)eMonster.MAX; i++)
                Console.Write(String.Format("{0}:{1},", i, (eMonster)i));
            m_eMonsterIdx = (eMonster)int.Parse(Console.ReadLine());

            switch (m_eMonsterIdx)
            {
                case eMonster.SLIME:
                    m_cMonster = new Player("Slime", 100, 100, 10, 0, 0, 100);
                    m_cMonster.SetInvetory(m_cItemManager.GetItem(ItemManager.eItem.WoodSword));
                    m_cMonster.SetInvetory(m_cItemManager.GetItem(ItemManager.eItem.WoodArmor));
                    m_cMonster.SetInvetory(m_cItemManager.GetItem(ItemManager.eItem.WoodRing));
                    break;
                case eMonster.SKELTON:
                    m_cMonster = new Player("Skelton", 200, 200, 20, 10, 0, 100);
                    m_cMonster.SetInvetory(m_cItemManager.GetItem(ItemManager.eItem.BoneSword));
                    m_cMonster.SetInvetory(m_cItemManager.GetItem(ItemManager.eItem.BoneArmor));
                    m_cMonster.SetInvetory(m_cItemManager.GetItem(ItemManager.eItem.BoneRing));
                    break;
                case eMonster.BOSS:
                    m_cMonster = new Player("Boss", 300, 300, 30, 15, 0, 100);
                    break;
                default:
                    m_eStage = eStage.FILED;
                    break;
            }
            m_eStage = eStage.BATTLE;
        }

        public bool EventBattle()
        {
            Console.WriteLine("####################");
            if (!m_cPlayer.Dead())
                m_cPlayer.Attack(m_cMonster);
            else
            {
                m_eStage = eStage.GAMEOVER;
                return true;
            }
            m_cMonster.Show();
            if (!m_cMonster.Dead())
                m_cMonster.Attack(m_cPlayer);
            else
            {
                Console.WriteLine(String.Format("몬스터가 쓰러뜨렸습니다!"));
                m_cPlayer.StillItem(m_cMonster);
                m_cPlayer.ShowInevtory();
                if (m_cPlayer.LvUp())
                {
                    Console.WriteLine("LvUp!");
                    m_cPlayer.Show();
                    m_eStage = eStage.TOWN;
                    return true;
                }
            }
            m_cPlayer.Show();
            Console.WriteLine("###################################");
            return false;
        }

        public void EvnetInitBattle() //몬스터와 싸울때 진입시에 초기화코드 //몬스터는 슬라임으로 정한다.
        {

        }

        public void EventAttack() //초기화에서 정해진 몬스터와 플레이어가 전투하기
        {
            m_cPlayer.Attack(m_cMonster);
        }

        public void EventSkill() //
        {
            
        }

        public void EventItem(int idx) //장비하기를 응용하여 아이템사용하기를 구현하고, 해당 이벤트 구현하기
        {
            Item cItem = m_cPlayer.GetInvetory(idx);
            m_cPlayer.ItemUse(cItem, m_cMonster);
        }

        public void EventRun()
        {

        }

        public void TurnEnd(Player cTarget)
        {
            
        }
    }
}