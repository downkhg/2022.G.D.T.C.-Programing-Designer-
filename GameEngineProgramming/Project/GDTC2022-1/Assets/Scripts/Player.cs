using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    public int nAttack;
    public int nHp;

    int nMaxHP;
    public int MaxHP 
    { 
        get => nMaxHP; 
        //set => nMaxHP = value; 
    }

    //public void SetMaxHP(int hp)
    //{
    //    nMaxHP = hp;
    //}
    public int GetMaxHP()
    {
        return nMaxHP;
    }

    public GUIStatusBar guiStatusBar;

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

    public int idx = 0;

    

    private void OnGUI()
    {
        GUI.Box(new Rect(0 + idx*100, 0, 100, 40), string.Format("HP:{0}\nAtk:{1}\n", nHp, nAttack));
    }

    // Start is called before the first frame update
    void Start()
    {
        nMaxHP = nHp;
        Debug.Log(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (guiStatusBar)
            guiStatusBar.SetState(nHp, nMaxHP);
    }
}
