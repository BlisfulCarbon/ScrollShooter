using System;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{ 
    public enum MoveStrategy
    {
        straight,
        wavy,
        stand
    }

    [Header("Wavy variables")] 
    public float amplitude;
    public float period;
    public float shift;
    public float yChange;
    private float xNew;
    private float yNew;

    private Rigidbody2D _body;
    public float speed;
    public MoveStrategy strategy;

    private void Start()
    {
        _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        switch (strategy)
        {
            case MoveStrategy.wavy:
                MoveWavy();
                break;
            case MoveStrategy.straight:
                MoveStraight();
                break;
            default:
                break;
        }
    }
    
    private void MoveStraight()
    {
        _body.velocity = new Vector2(_body.velocity.x, -speed);
    }

    private void MoveWavy()
    {
        yNew = transform.position.y - yChange;
        xNew = (float) (amplitude * Math.Sin(period * yNew) + shift);
        Vector2 temPosition = new Vector2(xNew, yNew);
        transform.position = temPosition;
    }
}