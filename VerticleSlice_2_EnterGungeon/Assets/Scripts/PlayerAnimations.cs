using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private Vector3 direction;
    [SerializeField] private Animator playerAnim;
    private PlayerAim aimScript;
    [SerializeField] Rigidbody _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        aimScript = gameObject.GetComponent<PlayerAim>();        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (this.transform.position - aimScript.mousePos).normalized;
        //Debug.Log(direction);

        playerAnim.SetFloat("MousePos Z", direction.z);
        playerAnim.SetFloat("MousePos X", direction.x);
        
        
        

        if(_rigidbody.velocity != Vector3.zero)
        {
            playerAnim.SetBool("IsWalking", true);
        }
        else
        {
            playerAnim.SetBool("IsWalking", false);
        }

    }
}
