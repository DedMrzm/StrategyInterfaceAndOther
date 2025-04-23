using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class BehaviourController : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    public Character Character;

    private IIdleableBehaviour _idleBehaviour;
    private IReactableBehaviour _reactionBehaviour;

    private bool _isReacting = false;

    private void Update()
    {
        if (_isReacting == false)
            Idle();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Character>() != null)
        {
            Debug.Log("REACT");
            _isReacting = true;
            Reaction();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Character>() != null)
        {
            _isReacting = false;
            Character = null;
        }
    }

    public void ControlBehaviours()
    {
        switch (_enemy.ReactionBehaviour)
        {
            case ReactionTypes.Dies:
                _reactionBehaviour = new Die(gameObject);
                break;
            case ReactionTypes.Chase:
                _reactionBehaviour = new Chase(Character.transform, transform);
                break;
            case ReactionTypes.RunAway:
                _reactionBehaviour = new RunAway(Character.transform, transform);
                break;
        }
        switch (_enemy.IdleBehaviour)
        {
            case IdleTypes.Idle:
                _idleBehaviour = new Idle();
                break;
            case IdleTypes.RandomWalking:
                _idleBehaviour = new RandomWalking(transform);
                break;
            case IdleTypes.Patrol:
                if(gameObject.GetComponent<PatrolPointsHolder>() != null)
                {
                    _idleBehaviour = new Patrol(_enemy.transform, gameObject.GetComponent<PatrolPointsHolder>().PatrolPoints);
                }
                else
                {
                    Debug.LogError("Невозможно патрулировать. Нужно добавить компонент PatrolPointsHolder");
                    _idleBehaviour = new Idle();
                }
                break;
        }
    }

    private void Idle() => _idleBehaviour.Idle();
    private void Reaction() => _reactionBehaviour.React();
}
