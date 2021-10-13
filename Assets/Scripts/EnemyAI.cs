using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform targetFlag;
    [SerializeField] private Transform[] targetBase;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float speedMove;
    [SerializeField] private CharacterController charController;
    private Vector3 moveVector;
    private Animator enemyAnimator;
    private Transform target;
    private float gravityValue = -9.8f;
    private int i;
    private void Start()
    {
        enemyAnimator = enemy.GetComponent<Animator>();
        target = targetFlag;
        TeamIdentify();
    }

    private void Update()
    {
        EnemyMove();
    }
    private void EnemyMove()
    {
        moveVector.y = gravityValue;
        moveVector = transform.forward - transform.position;
        moveVector *= speedMove;
        charController.Move(moveVector * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flag")
        {
            target = targetBase[i];
            Debug.Log(moveVector);
        }
    }
    private void TeamIdentify()
    {
        if (SingleGameSettings.redBlue)
        {
            this.gameObject.tag = "CharacterBlue";
            i = 1;
        }
        else
        {
            this.gameObject.tag = "CharacterRed";
            i = 0;
        }
    }
}
