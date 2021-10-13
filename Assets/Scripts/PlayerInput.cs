using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private float jumpPower;
    [SerializeField] private Joystick joystick;
    private float gravityForce;
    private Vector3 moveVector;
    [SerializeField] private GameObject character;
    [SerializeField] private Animator animatorMale;
    [SerializeField] private Animator animatorFemale;
    private CharacterController characterController;
    private void Start()
    {
        characterController = character.GetComponent<CharacterController>();
    }
    private void Update()
    {
        CharacterMove();
        GameGravity();
    }
    private void CharacterMove()
    {
        moveVector = Vector3.zero;
        moveVector.x = joystick.Horizontal * speedMove;
        moveVector.z = joystick.Vertical * speedMove;
        if (moveVector.x != 0 || moveVector.z != 0)
        {
            animatorMale.SetBool("Run", true);
            animatorFemale.SetBool("Run", true);
        }
        else
        {
            animatorMale.SetBool("Run", false);
            animatorFemale.SetBool("Run", false);
        }
        if (Vector3.Angle(Vector3.forward, moveVector) > 1f || Vector3.Angle(Vector3.forward, moveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
        moveVector.y = gravityForce;
        characterController.Move(moveVector * Time.fixedDeltaTime);
    }

    private void GameGravity()
    {
        if (!characterController.isGrounded)
        {
            gravityForce -= 20f * Time.fixedDeltaTime;
        }
        else
        {
            gravityForce = -1f;
        }
    }
}
