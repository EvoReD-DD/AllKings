using UnityEngine;
using UnityEngine.AI;

public class PlayerObstacleOn : MonoBehaviour
{
    private NavMeshObstacle navMeshObstacle;
    private void Start()
    {
        navMeshObstacle = this.GetComponent<NavMeshObstacle>();
    }
    private void Update()
    {
        if (EnemyAI.target == EnemyAI.targetFlagPos)
        {
            navMeshObstacle.enabled = false;
        }
        else
        {
            navMeshObstacle.enabled = true;
        }
    }
}
