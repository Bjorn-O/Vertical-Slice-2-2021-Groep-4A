using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private GameObject Firepoint;
    [SerializeField] private GameObject BulletPrefab;

    [SerializeField] private float _fireRate;
    [SerializeField] private float _reloadTime;
    private bool _canShoot;

    private Transform aimTransform;
    private RaycastFromCamera caster;

    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        caster = gameObject.GetComponent<RaycastFromCamera>();
    }

    private void Update()
    {
        GunRotation(caster.RaycastAim());
        if (Input.GetKey(KeyCode.Space) && _canShoot)
        {
            StartCoroutine("Shoot");
        }
    }

    private void GunRotation(Vector3 mouseposition)
    {
        aimTransform.LookAt(new Vector3(mouseposition.x, transform.position.y, mouseposition.z));
    }

    private IEnumerator Shoot()
    {
        _canShoot = false;
        Debug.Log("Shootin, tootin, be kind");
        Instantiate(BulletPrefab, Firepoint.transform.position, Firepoint.transform.rotation);
        yield return new WaitForSeconds(_fireRate);
        
        _canShoot = true;
    }
}
