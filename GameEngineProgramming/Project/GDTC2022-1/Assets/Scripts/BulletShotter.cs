using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShotter : MonoBehaviour
{
    public GameObject objBullet;
    public float Power;
    

    public void AimShot(GameObject objTarget)
    {
        GameObject copyBullet = Instantiate(objBullet,this.transform.position, Quaternion.identity);
        copyBullet.transform.LookAt(objTarget.transform);
        Rigidbody rigidbody = copyBullet.GetComponent<Rigidbody>();
        rigidbody.AddForce(copyBullet.transform.forward * Power);
        Bullet bullet = copyBullet.GetComponent<Bullet>();
        bullet.master = this.gameObject.GetComponent<Player>();
        Destroy(copyBullet, 10);
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject objTarget = GameObject.Find("Player");
        AimShot(objTarget);
    }
    

    // Update is called once per frame
    void Update()
    {
       
    }
}
