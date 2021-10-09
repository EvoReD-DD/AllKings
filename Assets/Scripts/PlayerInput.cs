using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private float jumpPower;
    [SerializeField] private Joystick joystick;
    private float gravityForce;
    private Vector3 moveVector;
    private CharacterController character;
    [SerializeField] private Animator animator;
    private float gravityValue = -9.8f;

    private void Start()
    {
        character = GetComponent<CharacterController>();
    }
    private void Update()
    {
        CharacterMove();
        GameGravity();
    }
    private void CharacterMove()
    {
        if (character.isGrounded)
        {
            moveVector = Vector3.zero;
            moveVector.x = joystick.Horizontal * speedMove;
            moveVector.z = joystick.Vertical * speedMove;
            if (moveVector.x != 0 || moveVector.z != 0)
            {
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("Run", false);
            }
            if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
            {
                Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
                transform.rotation = Quaternion.LookRotation(direct);
            }
            moveVector.y = gravityForce;
            character.Move(moveVector * Time.fixedDeltaTime);
        }
    }

    private void GameGravity()
    {
        if (!character.isGrounded)
        {
            gravityForce -= 20f * Time.fixedDeltaTime;
        }
        else
        {
            gravityForce = -1f;
        }
    }
}
