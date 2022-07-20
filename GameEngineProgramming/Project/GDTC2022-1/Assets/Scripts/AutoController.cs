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
    public E_AI_STATUS curAiStatus; //�������

    public void SetStatus(E_AI_STATUS state)//���¸� ������.
    {
        switch (state)
        {
            case E_AI_STATUS.FIND:
                break;
            case E_AI_STATUS.MOVE:
                break;
            case E_AI_STATUS.SHOT:
                ShotOn();
                break;
        }
        curAiStatus = state;
    }

    public void UpdateStatus()//���¿� ���� �������� ó���� ������.
    {
        switch (curAiStatus)
        {
            case E_AI_STATUS.FIND:
                FindProcess();
                break;
            case E_AI_STATUS.MOVE:
                if (objTarget != null)
                {
                    MoveProcess();
                }
                break;
            case E_AI_STATUS.SHOT:
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
                    objTarget = collider.gameObject;

                bCheck = true;
            }
        }

        if (bCheck == false)
        {
            objTarget = null;
            ShotOff();
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
            if (!isShot) ShotOn();
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(objTarget != null)
        {
            MoveProcess();
        }
    }

    private void FixedUpdate()//�������� �浹ó���ÿ� �����.
    {
        FindProcess();
    }

    private void OnDrawGizmos()//�浹������ �����ֱ����Ͽ� �߰�
    { 
        Gizmos.DrawWireSphere(playerController.transform.position, Site);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(playerController.transform.position, Range);
    }
}