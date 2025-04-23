using UnityEngine;

[RequireComponent(typeof(BehaviourController))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private ReactionTypes _reactionBehaviour = 0;
    [SerializeField] private IdleTypes _idleBehaviour = 0;

    public ReactionTypes ReactionBehaviour => _reactionBehaviour;
    public IdleTypes IdleBehaviour => _idleBehaviour;

    private BehaviourController _behaviourController;

    private void Awake()
    {
        _behaviourController = GetComponent<BehaviourController>();
    }

    public void SetBehavioursTypes(ReactionTypes currentReactionType, IdleTypes currentIdleType)
    {
        _reactionBehaviour = currentReactionType;
        _idleBehaviour = currentIdleType;

        _behaviourController.ControlBehaviours();
    }
}
