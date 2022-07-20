using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Gun gunSlot;
    public bool isAuto = false;

    //ó���� �ѹ��� ����ǰ��Ҷ�
    // Start is called before the first frame update
    void Start()
    {
        gunSlot = this.gameObject.GetComponent<Gun>();
    }
    //������ �ϴ� ���� ���������� ������Ʈ �ؾ��Ҷ�
    // Update is called once per frame
    void Update()
    {
        if (isAuto == false)
        {
            InputProcess();
        }
    }

    public void InputProcess()
    {
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
        if (Input.GetKey(KeyCode.A))
        {
            //vDir = Vector3.left;
            //vSpeed = vDir * Speed; //�ӵ�
            //vMove = vSpeed * Time.deltaTime; //1 ������ �� �̵���
            //transform.position += vMove; //��ġ�� ���Ⱚ�� ���ؼ� ��ġ�� ����ȴ�.
            MoveProcess(Vector3.left);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gunSlot != null) gunSlot.Shot();
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector3 vScreenPoint = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(vScreenPoint);

            RaycastHit raycastHit;
            if (Physics.Raycast(ray, out raycastHit))
            {
                Debug.Log("RaycastHit:" + raycastHit.transform.gameObject.name);
                this.gameObject.transform.LookAt(raycastHit.transform);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (gunSlot != null) gunSlot.Shot();
        }
    }

    public void MoveProcess(Vector3 vDir)
    {
        Vector3 vSpeed = vDir * Speed; //�ӵ�
        Vector3 vMove = vSpeed * Time.deltaTime; //1 ������ �� �̵���
        transform.position += vMove; //��ġ�� ���Ⱚ�� ���ؼ� ��ġ�� ����
    }

    public void Lookat(GameObject target)
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        this.gameObject.transform.LookAt(target.transform);
    }

    public void Shot()
    {
        gunSlot.Shot();
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
