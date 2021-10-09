using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    private void FixedUpdate()
    {
        CharacterRotate();
    }

    private void CharacterRotate()
    {
        transform.RotateAround(this.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
