using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoController : MonoBehaviour
{
    public PlayerController playerController;
    public float Site;
    public float Range;

    public GameObject objTarget;

    public bool isShot = false;

    public enum E_AI_STATUS { FIND, MOVE, SHOT }
    public E_AI_STATUS curAiStatus; //현재상태

    public void SetStatus(E_AI_STATUS state)//상태를 설정함.
    {
        Debug.Log("SetStatus("+state +")");
        switch (state)
        {
            case E_AI_STATUS.FIND:
                ShotOff();
                break;
            case E_AI_STATUS.MOVE:
                break;
            case E_AI_STATUS.SHOT:
                ShotOn();
                break;
        }
        curAiStatus = state;
    }

    public void UpdateStatus()//상태에 따른 지속적인 처리를 수행함.
    {
        switch (curAiStatus)
        {
            case E_AI_STATUS.FIND:
                FindProcess();
                break;
            case E_AI_STATUS.MOVE:
                //FindProcess();
                if (objTarget != null)
                {
                    // Range < fTargetDist < Site
                    if (DetectSiteTarget())
                    {
                        MoveProcess();
                    }
                    else
                    {
                        SetStatus(E_AI_STATUS.FIND);
                    } 
                }
                break;
            case E_AI_STATUS.SHOT:
                if (objTarget != null)
                {
                    if (DetectSiteTarget() == false)
                        SetStatus(E_AI_STATUS.FIND);
                }
                break;
        }
    }

    public void ShotOn()
    {
        StartCoroutine(ProcessShot(1));
    }

    public void ShotOff()
    {
        isShot = false;
    }

    IEnumerator ProcessShot(float time)//2
    {
        Debug.Log("ProcessShot 1: " + time);
        isShot = true;
        while (isShot)
        {
            playerController.Lookat(objTarget);
            playerController.Shot();
            yield return new WaitForSeconds(time);//2
        }
        Debug.Log("ProcessShot 2: " + time);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FindProcess()
    {
        Collider[] colliders = Physics.OverlapSphere(playerController.transform.position, Site);

        bool bCheck = false;
        foreach (var collider in colliders)
        {
            if (collider.gameObject.name != playerController.gameObject.name &&
                collider.tag == "Player")
            {
                if (objTarget == null)
                {
                    objTarget = collider.gameObject;
                    SetStatus(E_AI_STATUS.MOVE);
                }

                bCheck = true;
            }
        }

        if (bCheck == false)
        {
            objTarget = null;
            SetStatus(E_AI_STATUS.FIND);
        }
    }

    void MoveProcess()
    {
        Vector3 vPlayerPos = playerController.transform.position;
        Vector3 vTargetPos = objTarget.transform.position;
        float fTargetDist = Vector3.Distance(vPlayerPos, vTargetPos);
        Vector3 vTargetDir = vTargetPos - vPlayerPos;

     
        if (fTargetDist >= Range)
        {
            if (isShot) ShotOff();
            playerController.MoveProcess(vTargetDir.normalized);
            Debug.DrawLine(vPlayerPos, vTargetPos, Color.red);
        }
        else
        {
            Debug.DrawLine(vPlayerPos, vTargetPos, Color.green);
            SetStatus(E_AI_STATUS.SHOT);
            //if (!isShot) ShotOn();
        }    
    }

    bool DetectSiteTarget()
    {
        Vector3 vPlayerPos = playerController.transform.position;
        Vector3 vTargetPos = objTarget.transform.position;
        float fTargetDist = Vector3.Distance(vPlayerPos, vTargetPos);
        Vector3 vTargetDir = vTargetPos - vPlayerPos;
        float fTargetRad = objTarget.GetComponent<CapsuleCollider>().radius;

        if (fTargetDist <= Site + fTargetRad)
        {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
       //if(objTarget != null)
       // {
       //     MoveProcess();
       // }
    }

    private void FixedUpdate()//물리없는 충돌처리시에 사용함.
    {
        //FindProcess();
        UpdateStatus();
    }

    private void OnDrawGizmos()//충돌범위를 보여주기위하여 추가
    { 
        Gizmos.DrawWireSphere(playerController.transform.position, Site);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerController.transform.position, Range);
    }
}