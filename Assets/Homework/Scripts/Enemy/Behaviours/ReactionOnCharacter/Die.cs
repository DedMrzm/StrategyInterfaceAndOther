using UnityEngine;

public class Die : IReactableBehaviour
{
    private GameObject _gameObject;

    public Die(GameObject GameObject)
    {
        _gameObject = GameObject;
    }

    public void React()
    {
        _gameObject.SetActive(false);
        Debug.Log("DESTROY REACTION");
    }
}
