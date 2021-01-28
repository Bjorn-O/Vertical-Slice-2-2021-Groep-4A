using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float radius;
    public int speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.Self);
        // Gizmos.color = Color.red;
        // Gizmos.DrawSphere(transform.position, radius);
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        foreach(var hitCollider in hitColliders)
        {
            if (hitCollider.transform.tag == "Player")
            {
                hitCollider.gameObject.GetComponent<Player_Health>().TakeDamage();
                Destroy(this.gameObject);
            }
            else if (hitCollider.transform.tag == "Walls")
            {
                Destroy(this.gameObject);   
            }
        }
    }


}
