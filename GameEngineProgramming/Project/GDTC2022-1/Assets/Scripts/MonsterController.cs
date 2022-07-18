using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//AI를 이용하여 몬스터가 움직이도록 만드는 컴포너트.
public class MonsterController : MonoBehaviour
{
    private bool isShot;

    //타겟을 조준하고, (조준한 타겟을 바라본다).
    public void OnShot(bool on)
    {
        Debug.Log("Onshot:" + on);
        if (on) StartCoroutine(ProcessShot(2));
        isShot = on;  
    }

    IEnumerator ProcessShot(float time)
    {
        Debug.Log("ProcessShot 1: "+time);
        isShot = true;
        while (isShot)
        {
            GetComponent<BulletShotter>().AimShot(GameObject.Find("Player"));
            yield return new WaitForSeconds(time);
        }
        Debug.Log("ProcessShot 2: " + time);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    //외부에서 엑세스할일은 없지만, public을하여 유니티 에디터 실행중에 확인하기 쉽게 만듦.
    public float curTime;
    // Update is called once per frame
    void Update()
    {
        //if (isShot)
        //{
        //    if (curTime >= 1)
        //    {
        //        GetComponent<BulletShotter>().AimShot(GameObject.Find("Player"));
        //        curTime -= 1;
        //    }
        //    curTime += Time.deltaTime;
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log(gameObject.name + "::OnTriggerEnter2D(" + other.gameObject.name + ")");
            OnShot(true);
            //해당 변수를 접근시에 쉽게 보기위해서 private을 하고 접근함수인 OnShot을 작성하여 호출함.
            //GetComponent<BulletShotter>().isShot = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log(gameObject.name + "::OnTriggerExit(" + other.gameObject.name + ")");
            OnShot(false);
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.tag == "Player")
        {
            //Debug.Log(gameObject.name + "::OnTriggerEnter2D(" + collision.gameObject.name + ")");
            transform.LookAt(collision.transform);

            BulletShotter bulletShotter = GetComponent<BulletShotter>();
            //bulletShotter.AimShot();
        }
    }
}
