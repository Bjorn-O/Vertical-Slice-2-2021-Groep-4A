using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoS_Checker : MonoBehaviour
{
    [SerializeField] private string _targetTag;
    private GameObject _targetedPlayer;
    private Vector3 _targetDirection;

    private bool isVisible;

    void FixedUpdate()
    {
        _targetedPlayer = GameObject.FindGameObjectWithTag("Player");
        if (_targetedPlayer)
        {
            _targetDirection = (transform.position - _targetedPlayer.transform.position) * -1;
        }

        Ray ray = new Ray (transform.position, _targetDirection);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == _targetTag)
            {
                Debug.DrawRay(ray.origin, _targetDirection , Color.red);
                isVisible = true;
            } else
            {
                Debug.DrawRay(ray.origin, _targetDirection, Color.green);
                isVisible = false;
            }
        }
    }
}
