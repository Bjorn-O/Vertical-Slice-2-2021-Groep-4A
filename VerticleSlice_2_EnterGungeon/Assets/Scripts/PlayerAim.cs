using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    [SerializeField] private GameObject Firepoint;
    public GameObject BulletPrefab;
    private Transform aimTransform;
    public Vector2 mousePos;
    

     private void Awake()
    {
      aimTransform = transform.Find("Aim");
    }




    private void Update()
    {
        mousePos = Input.mousePosition;
        GunRotation(RaycastAim());
        HandleShooting();
        
    }

    private void GunRotation(Vector3 mouseposition)
    {
       
        aimTransform.LookAt(new Vector3(mouseposition.x, transform.position.y, mouseposition.z));

    }



    private Vector3 RaycastAim()
    {
        Vector3 temp1 = new Vector3();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
             temp1 = hit.point;
            return hit.point;
        }
        return temp1;
    }

 

    private Vector3 MouseAim(Vector2 mouse)
    {
        Vector3 worldposition = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, Camera.main.nearClipPlane));
        return worldposition;
    }

    private void HandleShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletPrefab, Firepoint.transform.position, Firepoint.transform.rotation);
        }
    }
}
