using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  
    public float speed = 20f;
    public int damage = 40;
    public Rigidbody rb;


    // Update is called once per frame
    void Update()
    {
        rb.velocity = transform.right * speed;
    }
}
