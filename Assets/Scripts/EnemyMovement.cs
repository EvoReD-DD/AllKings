using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private CharacterController charController;
    [SerializeField] private float speedMove;
    
    private NavMeshAgent agentNav;
    private Animator enemyAnimator;
    private Vector3 moveVector;
    private Transform target;
    private float gravityValue = -9.8f;
    private void Start()
    {
        enemyAnimator = enemy.GetComponent<Animator>();
        agentNav = this.GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
       EnemyMove();
    }
    private void EnemyMove()
    {
        if (TimerCount.pauseOn)
        {
            moveVector = Vector3.zero;
            moveVector = (EnemyAI.target.position - transform.position).normalized;
            Vector3 lookAt = EnemyAI.target.position;
            lookAt.y = transform.position.y;
            transform.LookAt(lookAt);
            moveVector.y = gravityValue;
            agentNav.SetDestination(EnemyAI.target.position);
            if (moveVector.x != 0 || moveVector.z != 0)
            {
                enemyAnimator.SetBool("Run", true);
            }
            else
            {
                enemyAnimator.SetBool("Run", false);
            }
        }
    }
}
