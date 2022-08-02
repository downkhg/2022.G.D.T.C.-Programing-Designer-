using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    public int Score;

    private void OnTriggerEnter(Collider other)
    {
        GameManager.GetInstance().nPlayerScore += Score;
        GameManager.nTotalScore += Score;
        Destroy(gameObject);
    }
}
