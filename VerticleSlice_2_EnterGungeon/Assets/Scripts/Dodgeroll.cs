using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodgeroll : MonoBehaviour
{
    Vector3 moveDirection;   
    Rigidbody rigidBody;
    [SerializeField] float rollSpeed = 80;
    private bool isRolling = false;
    [SerializeField] private float rollTimer = 0.7f;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();        
    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = rigidBody.velocity;
        
        Debug.Log(moveDirection);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("Roll");
        }
    }  

    private IEnumerator Roll()
    {
        isRolling = true;
        rigidBody.AddForce(transform.forward * rollSpeed * Time.deltaTime, ForceMode.Acceleration);
        yield return new WaitForSeconds(rollTimer);
        rigidBody.velocity = Vector3.zero;
        Debug.Log("yee");
        isRolling = false;

    }

}
