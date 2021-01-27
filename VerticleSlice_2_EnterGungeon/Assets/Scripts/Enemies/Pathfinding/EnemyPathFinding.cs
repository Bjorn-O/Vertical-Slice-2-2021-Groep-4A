using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPathFinding : MonoBehaviour
{
    public NavMeshAgent agent;
    private Enemies_BASE basic;

    void Awake()
    {
        basic = GetComponent<Enemies_BASE>();
        agent = GetComponent<NavMeshAgent>();
        Init(basic._speed, basic._acceleration, basic._angularSpeed, basic.minRange);
        agent.updateRotation = false;
    }

    void Update()
    {
        Pathing(RangeCheck());
        Debug.Log("Do I have a a path?" + agent.hasPath);
    }

    void Init(float speed, float acceleration, float angularSpeed, float minRange)
    {
        agent.speed = speed;
        agent.acceleration = acceleration;
        agent.angularSpeed = angularSpeed;
        agent.stoppingDistance = minRange;
    }

    private float RangeCheck()
    {
        return Vector3.Distance(basic.targetPlayer.transform.position, transform.position);
    }

    private void Pathing(float dis)
    {
        if (!basic.inSight)
        {
            agent.SetDestination(basic.targetPlayer.transform.position);
            agent.stoppingDistance = 0;
        } else
        {
            agent.SetDestination(basic.targetPlayer.transform.position);
            agent.stoppingDistance = basic.minRange;
        }
    }
}
