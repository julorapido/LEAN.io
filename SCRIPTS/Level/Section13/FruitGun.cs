using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitGun : MonoBehaviour
{
    public GameObject[] AllFruits;
    public float FireRate;
    public GameObject Gun;
    public float BulletSpeed;
     public float YBullet;
        public ParticleSystem FireSmoke;
        private Vector3 InitialProjectilePos;
    private Quaternion  InitialProjectileRotation;
    public GameObject Canon;
    private bool isFiring = false;
    public int Xcurb;
    void Start()
    {
        InitialProjectilePos = Gun.transform.position;
        InitialProjectileRotation = Gun.transform.localRotation;
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if (FindObjectOfType<GameManager>().gameHasEnded == false){
              StartCoroutine(FireFruit());
       }
    }

    IEnumerator FireFruit(){
            if (isFiring == false){
                isFiring = true;
                yield return new WaitForSeconds(FireRate);
                int RandomFruit = Random.Range(0, 8);
                FireSmoke.Play();
                LeanTween.scale(Canon, Vector3.one * 1.45f, 0.4f).setEasePunch();
                GameObject NewFruit = Instantiate(AllFruits[RandomFruit],new Vector3(InitialProjectilePos.x, InitialProjectilePos.y + 6f, InitialProjectilePos.z - 9f), InitialProjectileRotation, Gun.transform);
                NewFruit.transform.localScale = new Vector3(6f, 6f, 6f); 
                NewFruit.gameObject.tag = "OBSTACLE";
                NewFruit.GetComponent<Rigidbody>().AddForce(Xcurb * Time.deltaTime, YBullet * Time.deltaTime, BulletSpeed * Time.deltaTime);
                isFiring = false;
                yield return new WaitForSeconds(3);
                Destroy (NewFruit);
            }
         

    }
}
