using System.Collections.Generic;
using UnityEngine;

public class RandomWalking : IIdleableBehaviour
{
    private Transform _source;

    private const float TimeOfWalkInOneDirection = 1f;
    private const float Speed = 2f;

    private float _currentTimer = TimeOfWalkInOneDirection;

    private Vector3 _currentDirection;
    private List<Vector3> _directions = new List<Vector3>()
    {
        Vector3.right,
        Vector3.left,
        Vector3.forward,
        Vector3.back,
        Vector3.right + Vector3.forward,
        Vector3.right + Vector3.back,
        Vector3.left + Vector3.forward,
        Vector3.left + Vector3.back,
    };

    public RandomWalking(Transform source)
    {
        _source = source;
    }

    public void Idle()
    {
        if (_currentTimer >= TimeOfWalkInOneDirection)
        {
            _currentDirection = _directions[Random.Range(0, _directions.Count)];
            _currentTimer = 0f;
        }
        else
        {
            _currentTimer += Time.deltaTime;
            _source.Translate(_currentDirection.normalized * Speed * Time.deltaTime);
        }
    }

}
