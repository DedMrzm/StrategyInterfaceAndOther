using UnityEngine;

public class Chase : IReactableBehaviour
{
    private Transform _chasingTransform;
    private Transform _source;

    private const float ChasedDistance = 0.1f;
    private const float Speed = 4f;

    public Chase(Transform chasingTransform, Transform myTransform)
    {
        _chasingTransform = chasingTransform;
        _source = myTransform;
    }

    public void React()
    {
        Vector3 direction = GetDirectionTo(_chasingTransform);
        if (direction.magnitude >= ChasedDistance)
        {
            _source.Translate(direction.normalized * Speed * Time.deltaTime);
            Debug.Log("CHASE REACTION");
        }
    }

    private Vector3 GetDirectionTo(Transform target)
        => target.position - _source.position;
}
