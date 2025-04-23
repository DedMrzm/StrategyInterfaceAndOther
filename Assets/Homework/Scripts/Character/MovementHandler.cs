using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementHandler : MonoBehaviour
{
    private const string HorizontalAxisName = "Horizontal";
    private const string VerticalAxisName = "Vertical";

    private const float StopZone = 0.01f;

    private CharacterController _characterController;

    private const float _speed = 5f;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Control();
    }

    private void Control()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw(HorizontalAxisName), 0, Input.GetAxisRaw(VerticalAxisName));

        if (input.magnitude <= StopZone)
            return;

        Vector3 normalizedInput = input.normalized;

        Move(normalizedInput);
    }

    public void Move(Vector3 direction)
    {
        _characterController.Move(direction * _speed * Time.deltaTime);
    }
}
