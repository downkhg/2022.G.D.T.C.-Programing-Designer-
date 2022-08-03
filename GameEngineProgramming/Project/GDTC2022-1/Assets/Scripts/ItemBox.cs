using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public enum E_ITEM_BOX { IVENTORY, SCORE };

    public E_ITEM_BOX itemBoxSettting;
    public Item item;

    public int Score;

    private void OnTriggerEnter(Collider other)
    {
        switch(itemBoxSettting)
        {
            case E_ITEM_BOX.IVENTORY:
                {
                    Iventory iventory = other.GetComponent<Iventory>();
                    iventory.AddItem(item);
                    Destroy(gameObject);
                }
                break;
            case E_ITEM_BOX.SCORE:
                {
                    GameManager.GetInstance().nPlayerScore += Score;
                    GameManager.nTotalScore += Score;
                    Destroy(gameObject);
                }
                break;
        }        
    }
}
