using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    Vector3 moveDirection;
    Rigidbody rigidbody;
    [SerializeField] float rollSpeed = 80;
    private bool isRolling = false;
    [SerializeField] private float rollTimer = 0.7f;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRolling == false)
        {
            rigidbody.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime, 0, Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime);
        }

        moveDirection = rigidbody.velocity;

        Debug.Log(moveDirection);
        if (Input.GetKeyDown(KeyCode.Space) && isRolling == false && rigidbody.velocity != Vector3.zero)
        {
            StartCoroutine("Roll");
        }
    }

    private IEnumerator Roll()
    {
        isRolling = true;
        rigidbody.velocity = moveDirection.normalized * rollSpeed;
        yield return new WaitForSeconds(rollTimer);
        rigidbody.velocity = Vector3.zero;        
        isRolling = false;
    }
}

