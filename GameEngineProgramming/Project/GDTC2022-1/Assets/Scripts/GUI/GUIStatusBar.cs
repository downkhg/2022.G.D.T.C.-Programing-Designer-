using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIStatusBar : MonoBehaviour
{
    public Text textLable;
    public RectTransform rectBar;
    public RectTransform rectBarBG;
    public Color colorBar = Color.white;

    public void Set(string labletext, Color color, int state, int state_max)
    {
        textLable.text = labletext;
        //Image img = rectBar.gameObject.GetComponent<Image>();
        //img.color = color;
        rectBar.GetComponent<Image>().color = color;
        SetState(state, state_max);
    }

    public void SetState(float state, float state_max)
    {
        float fStateRat = state / state_max;
        Vector2 vMaxSize = rectBarBG.sizeDelta;
        Vector2 vBarSize = rectBar.sizeDelta;
        vBarSize.x = vMaxSize.x * fStateRat;
        rectBar.sizeDelta = vBarSize;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Set("text", colorBar, 10, 100);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
