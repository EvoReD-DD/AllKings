using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterRotation : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject playerOne;
    [SerializeField] private GameObject playerTwo;
    private float rotationSpeed = 20f;
    private bool rotateTouch = false;

    private void Update()
    {
        if (Input.GetMouseButton(0) && rotateTouch)
        {
            RotateTouch();
        }
        else
        {
            Invoke("CharacterRotate", 1f);
            rotateTouch = false;
        }
    }

    private void CharacterRotate()
    {
        playerOne.transform.RotateAround(playerOne.transform.position, Vector3.up, 10 * Time.deltaTime);
        playerTwo.transform.RotateAround(playerTwo.transform.position, Vector3.up, 10 * Time.deltaTime);
    }

    private void RotateTouch()
    {
        float rotationX = Input.GetAxis("Mouse X") * -rotationSpeed;
        playerOne.transform.RotateAround(playerOne.transform.position, Vector3.up, rotationX);
        playerTwo.transform.RotateAround(playerTwo.transform.position, Vector3.up, rotationX);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        rotateTouch = true;
    }
}
