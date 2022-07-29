using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIPlayerInfo : MonoBehaviour
{
    public Text textName;
    public Text textLv;
    public GUIStatusBar guiHP;

    public void Set(string name, int lv)
    {
        textName.text = name;
        textLv.text = string.Format("Lv.{0}", lv);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Set("test",99);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
