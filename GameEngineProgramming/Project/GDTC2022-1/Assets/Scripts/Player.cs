using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    [SerializeField]
    public Status sStatus;
    int nMaxHP;
    int nMaxMP;

    public int MaxHP 
    { 
        get => nMaxHP; 
        //set => nMaxHP = value; 
    }

    public int MaxMP
    {
        get => nMaxMP;
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
        target.sStatus.m_nHP -= sStatus.m_nStr - target.sStatus.m_nDef;
    }

    public bool Death()
    {
        if (sStatus.m_nHP <= 0)
            return true;
        else
            return false;
    }

    public int idx = 0;

    

    private void OnGUI()
    {
        //GUI.Box(new Rect(0 + idx*100, 0, 100, 40), sStatus.ToString());
    }

    // Start is called before the first frame update
    void Start()
    {
        nMaxHP = sStatus.m_nHP;
        nMaxMP = sStatus.m_nMP;
        Debug.Log(gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (guiStatusBar)
            guiStatusBar.SetState(sStatus.m_nHP, nMaxHP);
    }
}
