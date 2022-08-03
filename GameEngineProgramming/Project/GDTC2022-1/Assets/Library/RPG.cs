using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[System.Serializable]
public struct Status  //플레이어의 증가능력치를 구조체로 만들어 사용한다.
{
    public int m_nHP;
    public int m_nMP;
    public int m_nStr;
    public int m_nDef;
    public int m_nInt;

    public Status(int nStr = 0, int nDef = 0, int nInt = 0, int nHP = 0, int nMP = 0)
    {
        m_nHP = nHP;
        m_nMP = nMP;
        m_nStr = nStr;
        m_nDef = nDef;
        m_nInt = nInt;
    }
    public void AddStatus(int var)
    {
        m_nHP += var;
        m_nMP += var;
        m_nStr += var;
        m_nInt += var;
        m_nDef += var;
    }
    public static Status operator +(Status a, Status b)
    {
        return new Status(a.m_nHP + b.m_nHP, a.m_nMP + b.m_nMP,
                                a.m_nStr + b.m_nStr, a.m_nDef + b.m_nDef, a.m_nInt + b.m_nInt);
    }
    public static Status operator -(Status a, Status b)
    {
        return new Status(a.m_nHP - b.m_nHP, a.m_nMP - b.m_nMP,
                                a.m_nStr - b.m_nStr, a.m_nDef - b.m_nDef, a.m_nInt - b.m_nInt);
    }
}
[System.Serializable]
public class Item
{
    public enum eItemKind { Weapon, Armor, Acc, Potion, Throw }
    public Item(eItemKind eItemkind, string name, string comment, Status sStatus, int nGold)
    {
        m_eItemKind = eItemkind;
        m_strName = name;
        m_strComment = comment;
        m_sFunc = sStatus;
        m_nGold = nGold;
    }
    [SerializeField]
    eItemKind m_eItemKind;
    [SerializeField]
    string m_strName;
    [SerializeField]
    string m_strComment;
    [SerializeField]
    Status m_sFunc;
    [SerializeField]
    int m_nGold;

    public eItemKind ItemKind //Setter,Getter
    {
        get { return m_eItemKind; }
        set { m_eItemKind = value; }
    }
    public string Name //Setter,Getter
    {
        get { return m_strName; }
        set { m_strName = value; }
    }
    public string Comment //Setter,Getter
    {
        get { return m_strComment; }
        set { m_strComment = value; }
    }
    public Status Function
    {
        get { return m_sFunc; }
        set { m_sFunc = value; }
    }
    public int Gold
    {
        get { return m_nGold; }
        set { m_nGold = value; }
    }
}
[System.Serializable]
public class ItemManager //아이템매니저: 아이템을 보관해놓고 가져다쓰는 물류센터
{
    public enum eItem { WoodSword, BoneSword, WoodArmor, BoneArmor, WoodRing, BoneRing, HPPotion, MPPotion, Stone, Boom, MAX };
    [SerializeField]
    List<Item> m_listItemList;

    public ItemManager()
    {
        Debug.Log(this + "() Allocate Memory");
        m_listItemList = new List<Item>((int)eItem.MAX);
        Debug.Log(this + "() Allocate Items");
        m_listItemList.Add(new Item(Item.eItemKind.Weapon, "목검", "데미지증가", new Status(100), 100));
        m_listItemList.Add(new Item(Item.eItemKind.Weapon, "본소드", "데미지증가", new Status(200), 200));
        m_listItemList.Add(new Item(Item.eItemKind.Armor, "나무갑옷", "방어력증가", new Status(0, 100), 100));
        m_listItemList.Add(new Item(Item.eItemKind.Armor, "본아머", "방어력증가", new Status(0, 200), 200));
        m_listItemList.Add(new Item(Item.eItemKind.Acc, "나무반지", "체력증가", new Status(0, 0, 0, 100), 100));
        m_listItemList.Add(new Item(Item.eItemKind.Acc, "해골반지", "체력증가", new Status(0, 0, 0, 200), 200));
        m_listItemList.Add(new Item(Item.eItemKind.Potion, "힐링포션", "HP회복", new Status(0, 0, 0, 100), 100));
        m_listItemList.Add(new Item(Item.eItemKind.Potion, "마나포션", "MP회복", new Status(0, 0, 0, 0, 100), 100));
        m_listItemList.Add(new Item(Item.eItemKind.Throw, "짱돌", "단일개체데미지", new Status(100), 100));
        m_listItemList.Add(new Item(Item.eItemKind.Throw, "폭탄", "다수개체데미지", new Status(200), 200));
        Debug.Log(this + "() Allocate End");
    }

    public Item GetItem(eItem idx)
    {
        return m_listItemList[(int)idx];
    }
}

