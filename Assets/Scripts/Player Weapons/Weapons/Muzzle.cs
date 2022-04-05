using System.Collections;
using UnityEngine;

public class Muzzle : PoolObject
{
    [SerializeField] private float _timeToDestroy;

    private void OnEnable()
    {
        ReturnToPool(_timeToDestroy);
    }


}
