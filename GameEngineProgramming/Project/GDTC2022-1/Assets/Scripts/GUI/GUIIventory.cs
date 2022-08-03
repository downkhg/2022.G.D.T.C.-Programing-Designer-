using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIIventory : MonoBehaviour
{
    public List<GameObject> listButton;
    public RectTransform rectContent;

    public GameObject AddButton(Item item, GameObject prefab, Transform parent)
    {
        GameObject objItemButton = Instantiate(prefab, parent);
        GUIItemButton guiItemButton = objItemButton.GetComponent<GUIItemButton>();
        guiItemButton.Set(item, GameManager.GetInstance().guiInfoText);
        return objItemButton;
    }

    public void InitIventory(Iventory iventory)
    {
        Debug.Log("InitIventory:"+iventory.GetListItem().Count);
        GameObject prefabButton = Resources.Load("GUI/ItemButton") as GameObject;

        foreach(var item in iventory.GetListItem())
        {
            GameObject objButton = AddButton(item, prefabButton, rectContent.transform);
            listButton.Add(objButton);
        }
    }

    public void ReleaseIventory()
    {
        Debug.Log("ReleaseIventory:" + listButton.Count);
        foreach (var obj in listButton)
        {
            Destroy(obj);
        }
        listButton.Clear();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }
}
