using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//AI�� �̿��Ͽ� ���Ͱ� �����̵��� ����� ������Ʈ.
public class MonsterController : MonoBehaviour
{
    private bool isShot;

    //Ÿ���� �����ϰ�, (������ Ÿ���� �ٶ󺻴�).
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
    
    //�ܺο��� ������������ ������, public���Ͽ� ����Ƽ ������ �����߿� Ȯ���ϱ� ���� ����.
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
            //�ش� ������ ���ٽÿ� ���� �������ؼ� private�� �ϰ� �����Լ��� OnShot�� �ۼ��Ͽ� ȣ����.
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
