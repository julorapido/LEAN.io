using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Monster;
    public GameObject Projectile;

    public Vector3 ProjectileScale;

    public bool RandomMode;

    public float FireRate;
    public int BulletSpeedZ;
    public float BulletLiftetime;

    public int XBullet;
    public int YBullet;


    private GameObject NewProjectile;
    private bool BulletsFiring = false;
    private Vector3 InitialProjectilePos;
    private Quaternion  InitialProjectileRotation;
    void Start()
    {
        InitialProjectilePos = Monster.transform.position;
        InitialProjectileRotation = Monster.transform.localRotation;
        StartCoroutine(InfiniteFire());
    }

 
    IEnumerator InfiniteFire(){

            while (true)
            {
               BulletsFiring = true;
                yield return new WaitForSeconds(FireRate /2);
                int randomX = Random.Range(-XBullet, XBullet);
                 NewProjectile = Instantiate(Projectile,InitialProjectilePos, InitialProjectileRotation, Monster.transform);
                 NewProjectile.transform.localScale =  ProjectileScale;
                 if (RandomMode) {
                         NewProjectile.GetComponent<Rigidbody>().AddForce(randomX * Time.deltaTime, YBullet * Time.deltaTime, BulletSpeedZ * Time.deltaTime);
                 } else {
                         NewProjectile.GetComponent<Rigidbody>().AddForce(XBullet * Time.deltaTime, YBullet * Time.deltaTime, BulletSpeedZ * Time.deltaTime);
                 }
                 StartCoroutine(Disable(NewProjectile));
                yield return new WaitForSeconds(FireRate /2);

            }
    }

    IEnumerator Disable(GameObject g){
 
        yield return new WaitForSeconds(BulletLiftetime);
               Destroy(g);
    }


}
