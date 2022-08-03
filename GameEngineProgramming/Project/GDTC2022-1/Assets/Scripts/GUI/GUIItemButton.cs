using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUIItemButton : MonoBehaviour
{
    public Text textItemName;
    public Item citem;

    public void Set(ItemManager.eItem item, GUIInfoText guiInfoText)
    {
        Item getItem = GameManager.GetInstance().itemManager.GetItem(item);
        textItemName.text = getItem.Name;
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => guiInfoText.Set(getItem.Name, getItem.Comment));
    }

    public void Set(Item item, GUIInfoText guiInfoText)
    {
        textItemName.text = item.Name;
        Button button = GetComponent<Button>();
        string name = item.Name;
        string comment = item.Comment;
        button.onClick.AddListener(() => guiInfoText.Set(name, comment));
    }

    // Start is called before the first frame update
    void Start()
    {
        //Set(ItemManager.eItem.Stone, GameManager.GetInstance().guiInfoText);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
