using Unity.VisualScripting;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Character _character;

    [SerializeField] private ReactionTypes _reactionBehaviour = 0;
    [SerializeField] private IdleTypes _idleBehaviour = 0;

    private void Awake()
    {
        Spawn();
    }

    public void Spawn()
    {
        Enemy enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        enemy.GetComponent<BehaviourController>().Character = _character;

        if (gameObject.GetComponent<PatrolPointsHolder>() != null)
        {
            SetPatrolPointsTo(enemy.gameObject);
        }

        enemy.SetBehavioursTypes(_reactionBehaviour, _idleBehaviour);
    }

    private void SetPatrolPointsTo(GameObject source)
    {
        PatrolPointsHolder patrolPointsHolderOfSource = source.AddComponent<PatrolPointsHolder>();
        patrolPointsHolderOfSource.SetPatrolPoints(gameObject.GetComponent<PatrolPointsHolder>().PatrolPoints);
    }

}
