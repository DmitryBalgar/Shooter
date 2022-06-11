using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceShootTransition : Transition
{
    [SerializeField] private float _transitionShootRange;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        _transitionShootRange += Random.Range(-_rangeSpread, _rangeSpread);
    }
    private void Update()
    {
        if(Vector2.Distance(transform.position, Target.transform.position) < _transitionShootRange)
        {
            NeedTransit = true;
        }
    }
    
}
