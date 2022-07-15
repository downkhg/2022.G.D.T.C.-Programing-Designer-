using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject objBullet;
    public float Power;

    public void Shot()
    {
        GameObject copyBullet = Instantiate(objBullet, this.transform.position, Quaternion.identity);
        Rigidbody rigidbody = copyBullet.GetComponent<Rigidbody>();
        rigidbody.AddForce(this.transform.forward * Power);
        Bullet bullet = copyBullet.GetComponent<Bullet>();
        bullet.master = this.gameObject.GetComponent<Player>();
        Destroy(copyBullet, 10);
    }

}
