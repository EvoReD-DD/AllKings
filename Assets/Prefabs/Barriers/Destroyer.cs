using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void Update()
    {
        Destroy(gameObject, 3f);
    }
}
