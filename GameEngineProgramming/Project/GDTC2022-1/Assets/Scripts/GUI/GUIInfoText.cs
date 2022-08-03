using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIInfoText : MonoBehaviour
{
    RectTransform rectTransform;
    public Text textName;
    public Text textInfo;

    public void Set(string name, string info)
    {
        Debug.Log(this.ToString() + ".Set(" + name + "," +info+")");
        textName.text = name;
        textInfo.text = info;
        Show();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        //Set("Test", "test");
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.position = Input.mousePosition;
    }
}
