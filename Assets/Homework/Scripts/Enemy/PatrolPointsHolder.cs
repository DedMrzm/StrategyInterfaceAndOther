using System.Collections.Generic;
using UnityEngine;

public class PatrolPointsHolder : MonoBehaviour
{
    [SerializeField] private List<Transform> _patrolPoints;

    public List<Transform> PatrolPoints => _patrolPoints;

    public void SetPatrolPoints(List<Transform> patrolPoints)
    {
        _patrolPoints = patrolPoints;
    }
}
