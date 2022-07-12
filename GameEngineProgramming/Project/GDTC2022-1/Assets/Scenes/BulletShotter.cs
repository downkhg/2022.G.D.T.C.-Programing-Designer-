using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShotter : MonoBehaviour
{
    public GameObject objBullet;
    public float Power;

    //Ÿ���� �����ϰ�, (������ Ÿ���� �ٶ󺻴�).

    public void AimShot(GameObject objTarget)
    {
        GameObject copyBullet = Instantiate(objBullet,this.transform.position, Quaternion.identity);
        copyBullet.transform.LookAt(objTarget.transform);
        Rigidbody rigidbody = copyBullet.GetComponent<Rigidbody>();
        rigidbody.AddForce(copyBullet.transform.forward * Power);
        Destroy(copyBullet, 10);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject objTarget = GameObject.Find("Player");
        AimShot(objTarget);
    }

    float curTime;

    // Update is called once per frame
    void Update()
    {
        if (curTime >= 1)
        {
            AimShot(GameObject.Find("Player"));
            curTime -= 1;
        }
        curTime += Time.deltaTime;
    }
}
