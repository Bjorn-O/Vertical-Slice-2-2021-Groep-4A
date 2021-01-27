using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastFromCamera : MonoBehaviour
{
    public Vector3 RaycastAim()
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
}
