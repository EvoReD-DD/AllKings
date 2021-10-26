using UnityEngine;
using System.Collections;


public class PlayerInput : MonoBehaviour
{
    [SerializeField] private float speedMove;
    [SerializeField] private Joystick joystick;
    [SerializeField] private float maxSpeed;
    private float gravityForce;
    private Vector3 moveVector;
    [SerializeField] private GameObject character;
    [SerializeField] private Animator animatorMale;
    [SerializeField] private Animator animatorFemale;
    private float idleSpeed;

    private CharacterController characterController;
    private Vector3 direct;
    private void Start()
    {
        idleSpeed = speedMove;
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
            direct = Vector3.RotateTowards(transform.forward, moveVector, speedMove, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }
        moveVector.y = gravityForce;
        characterController.Move(moveVector * Time.deltaTime);
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
    public void LeapForwardOn()
    {
        StartCoroutine(moveSpeedChange());
    }
    private IEnumerator moveSpeedChange()
    {
        speedMove = maxSpeed;
        yield return new WaitForSeconds(1);
        speedMove = idleSpeed;
    }
}
