using System.Collections.Generic;
using UnityEngine;

public class Patrol : IIdleableBehaviour
{
    private Queue<Transform> _patrolPoints;
    private Transform _source;

    private Transform _currentPoint;

    private const float ArrivalDistance = 0.1f;
    private const float Speed = 5f;

    public Patrol(Transform source, List<Transform> patrolPoints)
    {
        _patrolPoints = new Queue<Transform>(patrolPoints);
        _source = source;
    }

    void IIdleableBehaviour.Idle()
    {
        _currentPoint = _patrolPoints.Peek();

        Vector3 direction = GetDirectionTo(_currentPoint);

        if(direction.magnitude > ArrivalDistance)
        {
            _source.Translate(direction.normalized * Speed * Time.deltaTime);
            return;
        }

        _patrolPoints.Dequeue();
        _patrolPoints.Enqueue(_currentPoint);
    }

    private Vector3 GetDirectionTo(Transform target) 
        => target.position - _source.position;

}
