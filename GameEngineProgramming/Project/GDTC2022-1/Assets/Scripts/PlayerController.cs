using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;
    public Gun gunSlot;
    public bool isAuto = false;

    //처음에 한번만 실행되게할때
    // Start is called before the first frame update
    void Start()
    {
        gunSlot = this.gameObject.GetComponent<Gun>();
    }
    //게임을 하는 동안 지속적으로 업데이트 해야할때
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
            //vSpeed = vDir * Speed; //속도
            //vMove = vSpeed * Time.deltaTime; //1 프레임 당 이동량
            //transform.position += vMove; //위치에 방향값을 더해서 위치가 변경된다.
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
        Vector3 vSpeed = vDir * Speed; //속도
        Vector3 vMove = vSpeed * Time.deltaTime; //1 프레임 당 이동량
        transform.position += vMove; //위치에 방향값을 더해서 위치가 변경
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

        //Vector3 vDir = new Vector3(fHorizontal, 0, fVertical);//방향
        //Vector3 vSpeed = vDir * Speed; //속도
        //Vector3 vMove = vSpeed * Time.deltaTime; //1 프레임 당 이동량
        //transform.position += vMove; //위치에 방향값을 더해서 위치가 변경된다.
        MoveProcess(new Vector3(fHorizontal, 0, fVertical));
    }

    //게임에 간단한 정보를 테스트용으로 정보를 보여주기위해사용 : 레거시GUI
    //private void OnGUI()
    //{
    //    float fHorizontal = Input.GetAxis("Horizontal");
    //    float fVertical = Input.GetAxis("Vertical");

    //    GUI.Box(new Rect(0, 0, 100, 100), "H/V"+fHorizontal.ToString() + "/"+ fVertical.ToString());
    //}

    
}
