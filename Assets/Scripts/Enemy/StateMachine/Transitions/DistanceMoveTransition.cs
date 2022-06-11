using UnityEngine;

public class DistanceMoveTransition : Transition
{
    [SerializeField] private float _transitionMoveRange;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        _transitionMoveRange += Random.Range(-_rangeSpread, _rangeSpread);
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, Target.transform.position) > _transitionMoveRange)
        {
            NeedTransit = true;
        }
    }

}
