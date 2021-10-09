using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform targetPosition;
    private Transform camera;
    private Vector3 position;
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
        camera.position = new Vector3(position.x + offset.x, camera.position.y , position.z + offset.z);
        camera.transform.LookAt(targetPosition);
    }
}
