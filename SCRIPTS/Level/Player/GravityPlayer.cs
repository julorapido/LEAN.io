using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPlayer : MonoBehaviour
{
    public float gravityScale = 75f; //The gravity scale
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
         rb.AddForce(Physics.gravity * gravityScale, ForceMode.Acceleration); //It has to be FixedUpdate, because it applies force to the rigidbody constantly.
    }
}
