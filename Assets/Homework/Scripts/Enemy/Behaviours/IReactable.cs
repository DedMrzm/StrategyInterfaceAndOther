using UnityEngine;

public interface IReactable
{
    void OnTriggerEnter(Collider other);

    void React();
}
