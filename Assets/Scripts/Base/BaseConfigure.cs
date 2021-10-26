using UnityEngine;

public class BaseConfigure : MonoBehaviour
{
    [SerializeField] private Transform baseRed;
    [SerializeField] private Transform baseBlue;
    [SerializeField] private Transform player;
    [SerializeField] private Transform enemy;

    private void Start()
    {
        BaseSideChanger();
    }

    private void BaseSideChanger()
    {
        if (SaveData.baseSide == 0)
        {
            baseBlue.position = player.position;
            baseRed.position = enemy.position;
        }
        else {
            baseBlue.position = enemy.position;
            baseRed.position = player.position;
        }
    }
}
