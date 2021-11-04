using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform targetPosition;
    private Transform camera;
    private Vector3 position;
    private float smooth = 0.5f;

    private void Start()
    {
        camera = GetComponent<Transform>();
    }

    private void LateUpdate()
    {
        CameraFollowing();
    }

    private void CameraFollowing()
    {
        position.x = targetPosition.position.x;
        position.z = targetPosition.position.z;
        camera.position = new Vector3(position.x + offset.x, camera.position.y, position.z + offset.z);
        var targetRotation = Quaternion.LookRotation(targetPosition.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smooth * Time.deltaTime);
    }
}
