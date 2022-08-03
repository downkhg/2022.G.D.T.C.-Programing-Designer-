using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iventory : MonoBehaviour
{
    [SerializeField]
    List<Item> listIventory;

    public List<Item> GetListItem() { return listIventory; }

    public void AddItem(Item item)
    {
        listIventory.Add(item);
    }

    public void RemoveItem(string name)
    {
        Item item = listIventory.Find(item => item.Name == name);
        listIventory.Remove(item);
    }

    public void RemoveItem(int idx)
    {
        listIventory.RemoveAt(idx);
    }


    public void OnGUI()
    {
        int w = 100;
        int h = 20;
        for(int i = 0; i < listIventory.Count; i++)
        {
            GUI.Box(new Rect(0, h * i, w, h), listIventory[i].Name);
        }
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
