using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies_BASE : MonoBehaviour
{
    //TO DO: MAKE GETTERS AND SETTERS BECAUSE THIS SHIT IS BAD :>
    [SerializeField] private int _health;
    [SerializeField] private string _targetTag;

    public float _speed;
    public float _acceleration;
    public float _angularSpeed;
    public float minRange;
    public bool inSight;

    public LoS_Checker losCheck;
    public GameObject targetPlayer;

    void Awake()
    {
        losCheck = GetComponent<LoS_Checker>();
        targetPlayer = GameObject.FindGameObjectWithTag(_targetTag);
    }

    void Update()
    {
        inSight = losCheck.SightChecker(this.transform, targetPlayer, _targetTag);
        Debug.Log(inSight);
    }
}
