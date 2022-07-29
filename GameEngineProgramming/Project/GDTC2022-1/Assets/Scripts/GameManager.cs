using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject objPlayer;
    public GUIPlayerInfo guiPlayerInfo;

    public enum E_SCENE_STATE { TITLE, PLAY, GAMEOVER, MAX }
    public E_SCENE_STATE curState;

    public List<GameObject> listSecnes;

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

    public void EventPlayerInfoUpdate()
    {
        if (guiPlayerInfo && objPlayer)
        {
            Player player = objPlayer.GetComponent<Player>();
            guiPlayerInfo.Set(objPlayer.name, 0);
            guiPlayerInfo.guiHP.Set("HP", Color.red, player.nHp, player.MaxHP);
        }
    }

    public void EventChangeScene(int state)
    {
        SetSceneStatus((E_SCENE_STATE)state);
    }
}
