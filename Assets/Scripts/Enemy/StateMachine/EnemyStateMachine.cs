using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _firstState;
    private PlayerHealth _target;
    private State _currentState;

    public State Current => _currentState;

    void Start()
    {
        _target = EventManager.Instance.PlayerHealth;
        Reset(_firstState);
    }
    private void Update()
    {
        if (_currentState == null)
            return;
        var nextStete = _currentState.GetNextState();
        if (nextStete != null)
            Transit(nextStete);
    }
    private void Reset(State startState)
    {
        _currentState = startState;

        if (_currentState != null)
            _currentState.Enter(_target);
    }
    private void Transit(State nextState)
    {
        if (_currentState != null)
            _currentState.Exit();
        _currentState = nextState;
        if (_currentState != null)
            _currentState.Enter(_target);
    }
}
