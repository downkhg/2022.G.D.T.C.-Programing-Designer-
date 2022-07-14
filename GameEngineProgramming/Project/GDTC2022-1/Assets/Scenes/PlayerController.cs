using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    //ó���� �ѹ��� ����ǰ��Ҷ�
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //������ �ϴ� ���� ���������� ������Ʈ �ؾ��Ҷ�
    // Update is called once per frame
    void Update()
    {
        Vector3 vDir,vSpeed, vMove;
        if (Input.GetKey(KeyCode.W))
        {
            MoveProcess(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveProcess(Vector3.back);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveProcess(Vector3.right);
        }
        if(Input.GetKey(KeyCode.A))
        {
            //vDir = Vector3.left;
            //vSpeed = vDir * Speed; //�ӵ�
            //vMove = vSpeed * Time.deltaTime; //1 ������ �� �̵���
            //transform.position += vMove; //��ġ�� ���Ⱚ�� ���ؼ� ��ġ�� ����ȴ�.
            MoveProcess(Vector3.left);
        }
    }

    void MoveProcess(Vector3 vDir)
    {
        Vector3 vSpeed = vDir * Speed; //�ӵ�
        Vector3 vMove = vSpeed * Time.deltaTime; //1 ������ �� �̵���
        transform.position += vMove; //��ġ�� ���Ⱚ�� ���ؼ� ��ġ�� ����
    }

    void ProcessInputAxis()
    {
        float fHorizontal = Input.GetAxis("Horizontal");
        float fVertical = Input.GetAxis("Vertical");

        //Vector3 vDir = new Vector3(fHorizontal, 0, fVertical);//����
        //Vector3 vSpeed = vDir * Speed; //�ӵ�
        //Vector3 vMove = vSpeed * Time.deltaTime; //1 ������ �� �̵���
        //transform.position += vMove; //��ġ�� ���Ⱚ�� ���ؼ� ��ġ�� ����ȴ�.
        MoveProcess(new Vector3(fHorizontal, 0, fVertical));
    }

    //���ӿ� ������ ������ �׽�Ʈ������ ������ �����ֱ����ػ�� : ���Ž�GUI
    //private void OnGUI()
    //{
    //    float fHorizontal = Input.GetAxis("Horizontal");
    //    float fVertical = Input.GetAxis("Vertical");

    //    GUI.Box(new Rect(0, 0, 100, 100), "H/V"+fHorizontal.ToString() + "/"+ fVertical.ToString());
    //}

    
}
