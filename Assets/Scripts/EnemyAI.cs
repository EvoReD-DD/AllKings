using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform targetFlag;
    [SerializeField] private Transform[] targetBase;
    [SerializeField] private GameObject enemy;
    [SerializeField] private float speedMove;
    [SerializeField] private CharacterController charController;
    [SerializeField] private GameObject baseLvl;
    private Vector3 moveVector;
    private Animator enemyAnimator;
    private Transform target;
    private float gravityValue = -9.8f;
    private int i;
    private void Awake()
    {
        TeamIdentify();
    }
    private void Start()
    {
        enemyAnimator = enemy.GetComponent<Animator>();
        target = targetFlag;
    }

    private void Update()
    {
        EnemyMove();
    }
    private void EnemyMove()
    {
        moveVector.y = gravityValue;
        moveVector = target.transform.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.forward, moveVector);
        moveVector *= speedMove;
        charController.Move(moveVector * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flag")
        {
            target = targetBase[i];
        }
    }
    private void TeamIdentify()
    {
        if (SaveData.redBlue)
        {
            this.gameObject.tag = "CharacterBlue";
            enemy.tag = "CharacterBlue";
            i = 0;
        }
        else
        {
            this.gameObject.tag = "CharacterRed";
            enemy.tag = "CharacterRed";
            i = 1;
            baseLvl.transform.Rotate(0, 0, -180);
            Debug.Log("rotate");
        }
    }
}
