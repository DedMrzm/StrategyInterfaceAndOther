using UnityEngine;

public class RunAway : IReactableBehaviour
{

    private Transform _chasingTransform;
    private Transform _source;

    private const float RunAwayDistance = 10f;
    private const float Speed = 3f;

    public RunAway(Transform chasingTransform, Transform myTransform)
    {
        _chasingTransform = chasingTransform;
        _source = myTransform;
    }

    public void React()
    {
        Vector3 direction = GetDirectionTo(_chasingTransform);
        if (direction.magnitude <= RunAwayDistance)
        {
            _source.Translate(-(new Vector3(direction.x, 0, direction.z).normalized) * Speed * Time.deltaTime);
            Debug.Log("RUN AWAY REACTION");
        }
    }

    private Vector3 GetDirectionTo(Transform target)
        => target.position - _source.position;
}
