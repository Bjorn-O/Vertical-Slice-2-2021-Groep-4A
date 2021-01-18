using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody _rigidbody;
    [SerializeField] float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0, Input.GetAxis("Vertical") * moveSpeed);
    }
}
