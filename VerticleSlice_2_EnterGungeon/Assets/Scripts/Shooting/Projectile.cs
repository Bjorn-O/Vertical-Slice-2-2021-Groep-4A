using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  
    public float speed;
    public int damage;
    public float radius;
    
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.Self);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach(var hitCollider in hitColliders)
        {
            if (hitCollider.transform.tag == "Enemy")
            {
                hitCollider.gameObject.GetComponent<Enemies_BASE>().TakeDamage(damage);
                Destroy(this.gameObject);
            }
            else if (hitCollider.transform.tag == "Walls")
            {
                Destroy(this.gameObject);   
            }
        }
    }
}
