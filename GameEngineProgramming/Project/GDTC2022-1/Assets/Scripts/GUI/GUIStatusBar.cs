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
        rectBar.GetComponent<Image>().color = color;//이미지는 크래스이므로 인스턴스(원본)에 접근하여 값을 변경할수있다.
        SetState(state, state_max);
    }

    public void SetState(float state, float state_max)
    {
        float fStateRat = state / state_max;
        Vector2 vMaxSize = rectBarBG.sizeDelta;
        Vector2 vBarSize = rectBar.sizeDelta;
        vBarSize.x = vMaxSize.x * fStateRat;
        rectBar.sizeDelta = vBarSize;
        //rectBar.sizeDelta.x = vMaxSize.x * fStateRat; //구조체는 리턴될때 복사되므로 원본에 참조접근아니므로, 다음과 같은 문법은 활용할 수 없다.
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
