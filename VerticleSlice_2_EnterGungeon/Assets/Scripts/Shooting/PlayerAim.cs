using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private GameObject Firepoint;
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Animator gunAnimatior;
    [SerializeField] private float shootDelay = 0.2f;
    [SerializeField] private float reloadTime;

    private bool canShoot = true;
    private bool isReloading = false;

    private int maxAmmo = 8;
    private int currentAmmo;

    private Transform aimTransform;
    private RaycastFromCamera caster;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        caster = gameObject.GetComponent<RaycastFromCamera>();
        playerMovement = gameObject.GetComponent<PlayerMovement>();
        currentAmmo = maxAmmo;
    }

    private void Update()
    {
        GunRotation(caster.RaycastAim());
        HandleShooting();
        gunAnimatior.SetBool("isReloading", isReloading);
    }

    private void GunRotation(Vector3 mouseposition)
    {
        aimTransform.LookAt(new Vector3(mouseposition.x, transform.position.y, mouseposition.z));
    }

     private void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && playerMovement.isRolling == false && canShoot == true && isReloading == false)
        {
            Debug.Log("Pew");
            Instantiate(BulletPrefab, Firepoint.transform.position, Firepoint.transform.rotation);
            gunAnimatior.SetTrigger("Shoot");
            StartCoroutine("ShootDelay");
            currentAmmo --;            
            if (currentAmmo <= 0 && isReloading == false)
            {
                StartCoroutine("Reload");
            }
        }        
    }

    private IEnumerator ShootDelay()
    {
        canShoot = false;        
        yield return new WaitForSeconds(shootDelay);
        
        canShoot = true;
        gunAnimatior.ResetTrigger("Shoot");
    }

    private IEnumerator Reload()
    {
        isReloading = true;       
        
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;        
        isReloading = false;
    }
}
