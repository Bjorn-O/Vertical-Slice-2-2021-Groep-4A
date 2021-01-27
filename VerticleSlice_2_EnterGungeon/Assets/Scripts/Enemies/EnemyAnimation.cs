using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private EnemyPathFinding path;
    private Enemies_BASE main;
    [SerializeField] private Animator anim;
    [SerializeField] private Transform aim;
    [SerializeField] private GameObject hand;
    private Vector3 target;
    private Vector3 Lookdirection;
    private Vector3 newScale;
    private bool isFacingRight;
    private float speed = 360f;

    private Vector3 tempDir;

    void Awake()
    {
        path = GetComponentInParent<EnemyPathFinding>();
        main = GetComponentInParent<Enemies_BASE>();
        Vector3 newScale = aim.transform.localScale;
    }

    void Update()
    {
        target = main.targetPlayer.transform.position;
        Lookdirection = (transform.position - target).normalized;
        PositionChecker();
        GunRotation();
        anim.SetFloat("TargetX", Lookdirection.x);
        anim.SetFloat("TargetZ", Lookdirection.z);
        anim.SetFloat("WalkSpeed", path.agent.velocity.magnitude);
    }

    void GunRotation()
    {
        Vector3 diff = target - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.z, diff.x) * Mathf.Rad2Deg;
        hand.transform.rotation = Quaternion.Euler(90f,0, rot_z+180);
        if (isFacingRight)
        {
            hand.transform.localScale = new Vector3(-4,-4,0);
        } else
        {
            hand.transform.localScale = new Vector3(-4,4,0);
        }
    }

    void PositionChecker()
    {
        if (target.x < transform.position.x && target.z < transform.position.z)
        {
            //Left-Below
            if (isFacingRight)
            {
                Flip();
                isFacingRight = false;
            }
        }
        else if(target.x < transform.position.x && target.z > transform.position.z)
        {
            if (isFacingRight)
            {
                Flip();
                isFacingRight = false;
            }
        }
        else if(target.x > transform.position.x && target.z < transform.position.z)
        {
            if (!isFacingRight)
            {
                Flip();
                isFacingRight = true;
            }
        }
        else if(target.x > transform.position.x && target.z > transform.position.z)
        {
            if (!isFacingRight)
            {
                Flip();
                isFacingRight = true;
            }
        }
    }

    void Flip()
    {
        Vector3 currentRotation = aim.transform.eulerAngles;
        currentRotation.z += 180;
        aim.transform.localEulerAngles = currentRotation;
    }
}
