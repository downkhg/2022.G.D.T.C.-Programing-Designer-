using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed;

    //처음에 한번만 실행되게할때
    // Start is called before the first frame update
    void Start()
    {
        
    }
    //게임을 하는 동안 지속적으로 업데이트 해야할때
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
            //vSpeed = vDir * Speed; //속도
            //vMove = vSpeed * Time.deltaTime; //1 프레임 당 이동량
            //transform.position += vMove; //위치에 방향값을 더해서 위치가 변경된다.
            MoveProcess(Vector3.left);
        }
    }

    void MoveProcess(Vector3 vDir)
    {
        Vector3 vSpeed = vDir * Speed; //속도
        Vector3 vMove = vSpeed * Time.deltaTime; //1 프레임 당 이동량
        transform.position += vMove; //위치에 방향값을 더해서 위치가 변경
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
