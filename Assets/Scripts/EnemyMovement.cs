using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private CharacterController charController;
    [SerializeField] private float speedMove;
    private Animator enemyAnimator;
    private Vector3 moveVector;
    private Transform target;
    private float gravityValue = -9.8f;
    private void Start()
    {
        enemyAnimator = enemy.GetComponent<Animator>();
    }
    private void Update()
    {
       EnemyMove();
    }
    private void EnemyMove()
    {
        if (TimerCount.pauseOn)
        {
            target = EnemyAI.target;
            moveVector = Vector3.zero;
            moveVector = (target.position - transform.position).normalized;
            Vector3 lookAt = target.position;
            lookAt.y = transform.position.y;
            transform.LookAt(lookAt);
            moveVector.y = gravityValue;
            charController.Move(moveVector * speedMove * Time.fixedDeltaTime);
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
