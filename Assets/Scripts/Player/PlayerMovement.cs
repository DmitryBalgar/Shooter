using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private AnimationCurve _speedCurve;
    private Rigidbody2D _rb;
    public Vector2 MovementDirection { get; set; }
    public Vector2 ShootingDirection { get; set; }
    public Vector2 CurrentVelocity { get; private set; }



    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        _rb.velocity = new Vector2(_speedCurve.Evaluate(MovementDirection.x), _speedCurve.Evaluate(MovementDirection.y));
        _rb.angularVelocity = 0;
        CurrentVelocity = _rb.velocity / new Vector2(_speedCurve.keys[0].value, _speedCurve.keys[1].value); ;

        if (MovementDirection != Vector2.zero && ShootingDirection == Vector2.zero)
        {
            float angle = Mathf.Atan2(MovementDirection.y, MovementDirection.x) * Mathf.Rad2Deg;
            _rb.rotation = angle;
        }
        if (ShootingDirection != Vector2.zero)
        {
            float angle = Mathf.Atan2(ShootingDirection.y, ShootingDirection.x) * Mathf.Rad2Deg;
            _rb.rotation = angle;

        }


    }
}
