using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GUIItemButton : MonoBehaviour,IPointerDownHandler,IPointerUpHandler//GUIContent: ��κ� ��ü���� ������ �������̽��� ������ Ŭ������ ���߻���� �����Ǿ��ִ�.
{
    public Text textItemName;
    public Item citem;

    public void Set(ItemManager.eItem item, GUIInfoText guiInfoText)
    {
        Item getItem = GameManager.GetInstance().itemManager.GetItem(item);
        textItemName.text = getItem.Name;
        citem = getItem;
        //button.onClick.AddListener(() => guiInfoText.Set(getItem.Name, getItem.Comment));

        //IPointerDownHandler pointerDownHandler = new IPointerUpHandler(); //�������̽��� �߻�Ŭ������ �����̹Ƿ� ��üȭ�� �Ұ����ϴ�.
    }

    public void Set(Item item, GUIInfoText guiInfoText)
    {
        textItemName.text = item.Name;
        Button button = GetComponent<Button>();
        citem = item;
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        GameManager.GetInstance().guiInfoText.Set(citem.Name, citem.Comment);
        GameManager.GetInstance().guiInfoText.Show();
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        GameManager.GetInstance().guiInfoText.Hide();
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
