using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_BASE : MonoBehaviour
{
    //TO DO: MAKE GETTERS AND SETTERS BECAUSE THIS SHIT IS BAD :>
    [SerializeField] private int _health;
    [SerializeField] private string _targetTag;

    public float _speed;
    public float _acceleration;
    public float _angularSpeed;
    public float minRange;
    public bool inSight;
    public bool isDead;

    public LoS_Checker losCheck;
    public GameObject targetPlayer;
    public Transform firePoint;
    public GameObject bulletPreFab;
    public Animator anim;
    public GameObject deathObject;

    private bool isShooting;

    protected void Awake()
    {
        losCheck = GetComponent<LoS_Checker>();
        targetPlayer = GameObject.FindGameObjectWithTag(_targetTag);
    }
    
    protected void Update()
    {
        inSight = losCheck.SightChecker(this.transform, targetPlayer, _targetTag);
        if (inSight && !isShooting)
        {
            StartCoroutine("WaitForShootingAnimation");
        }
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathObject, transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }

    private IEnumerator WaitForShootingAnimation()
    {   
        isShooting = true;
        anim.SetBool("shootingAnim", isShooting);

        while (!anim.GetCurrentAnimatorStateInfo(0).IsTag("Shoot"))
        {
            yield return null;
        }

        while (anim.GetCurrentAnimatorStateInfo(0).IsTag("Shoot")) 
        {
            yield return null;
        }

        Shoot();

        isShooting = false;
        anim.SetBool("shootingAnim", isShooting);
    }

    protected void Shoot()
    {
        Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
    }
}
