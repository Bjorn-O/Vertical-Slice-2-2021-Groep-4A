using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoS_Checker : MonoBehaviour
{
    private Vector3 _targetDirection;
    public bool SightChecker(Transform orgin ,GameObject targetObject, string targetTag)
    {
        if (targetObject)
        {
            _targetDirection = (orgin.position - targetObject.transform.position) * -1;
        }
        
        Ray ray = new Ray (orgin.position, _targetDirection);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == targetTag)
            {
                Debug.DrawRay(ray.origin, _targetDirection , Color.red);
                return true;
            } 
            else
            {
                Debug.DrawRay(ray.origin, _targetDirection, Color.green);
                return false;
            }
        }
        else
        {
            return false; 
        }
    }
}
