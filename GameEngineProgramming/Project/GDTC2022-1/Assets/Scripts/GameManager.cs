using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject objPlayer;
    public GUIPlayerInfo guiPlayerInfo;
    public ItemManager itemManager;

    public static int nTotalScore;
    public int nPlayerScore;

    public GameObject objPopupLayer;
    public GUIInfoText guiInfoText;
    public GUIIventory guiIventory;
    public bool isPopup;

    public void ShowPopup()
    {
        objPopupLayer.SetActive(true);
        isPopup = true;
    }

    public void HidePopup()
    {
        objPopupLayer.SetActive(false);
        isPopup = false;
    }

    public enum E_SCENE_STATE { TITLE, PLAY, GAMEOVER, MAX }
    public E_SCENE_STATE curState;

    public List<GameObject> listSecnes;

    static GameManager instance;

    public static GameManager GetInstance() { return instance; }

    private void Awake()
    {
        itemManager = new ItemManager();
        HidePopup();
        instance = this;
    }

    public void ShowScene(E_SCENE_STATE state)
    {
        for(int i = 0; i < (int)E_SCENE_STATE.MAX; i++)
        {
            if(i == (int)state)
            {
                listSecnes[i].SetActive(true);
            }
            else
                listSecnes[i].SetActive(false);
        }
    }

    void SetSceneStatus(E_SCENE_STATE state)
    {

        switch(state)
        {
            case E_SCENE_STATE.TITLE:
                Time.timeScale = 0;
                break;
            case E_SCENE_STATE.PLAY:
                EventCreateItemtoryItem(new Vector3(0,1.5f,-1), itemManager.GetItem(ItemManager.eItem.HPPotion));
                EventCreateItemtoryItem(new Vector3(1, 1.5f, -1), itemManager.GetItem(ItemManager.eItem.MPPotion));
                EventCreateItemtoryItem(new Vector3(2, 1.5f, -1), itemManager.GetItem(ItemManager.eItem.WoodSword));
                EventCreateItemtoryItem(new Vector3(-1, 1.5f, -1), itemManager.GetItem(ItemManager.eItem.WoodArmor));
                EventCreateItemtoryItem(new Vector3(-2, 1.5f, -1), itemManager.GetItem(ItemManager.eItem.WoodRing));

                Time.timeScale = 1;
                break;
            case E_SCENE_STATE.GAMEOVER:
                Time.timeScale = 0;
                break;
        }
        ShowScene(state);
        curState = state;
    }

    void UpdateStatus()
    {
        switch (curState)
        {
            case E_SCENE_STATE.TITLE:
                break;
            case E_SCENE_STATE.PLAY:

                UpdateIventoryButton();
                EventPlayerInfoUpdate();
                break;
            case E_SCENE_STATE.GAMEOVER:
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        SetSceneStatus(curState);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateStatus();
    }

    void UpdateIventoryButton()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log("Iventory Call");
            if (isPopup)
            {
                guiIventory.ReleaseIventory();
                HidePopup();
            }
            else
            {
                guiIventory.InitIventory(objPlayer.GetComponent<Iventory>());
                ShowPopup();
            }
        }

        if(isPopup && guiInfoText.gameObject.activeSelf)
        {
            if(Input.GetMouseButtonUp(0))
            {
                guiInfoText.Hide();
            }
        }
    }

    public void EventPlayerInfoUpdate()
    {
        if (guiPlayerInfo && objPlayer)
        {
            Player player = objPlayer.GetComponent<Player>();
            guiPlayerInfo.Set(objPlayer.name, 0);
            guiPlayerInfo.guiHP.Set("HP", Color.red, player.sStatus.m_nHP, player.MaxHP);
        }
    }

    public void EventChangeScene(int state)
    {
        SetSceneStatus((E_SCENE_STATE)state);
    }

    public void EventCreateItemtoryItem(Vector3 pos, Item item)
    {
        GameObject prefabItemBox = Resources.Load("Prefabs/InventoryItem") as GameObject;
        GameObject objItemBox = Instantiate(prefabItemBox);
        ItemBox itemBox = objItemBox.GetComponent<ItemBox>();
        objItemBox.transform.position = pos;
        itemBox.item = item;
    }
}
