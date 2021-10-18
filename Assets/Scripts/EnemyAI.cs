using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private Transform targetFlag;
    [SerializeField] private Transform[] targetBase;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject baseLvl;
    public static Transform target;
    private int i;
    private void Awake()
    {
        TeamIdentify();
    }
    private void Start()
    {
        target = targetFlag;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Flag")
        {
            target = targetBase[i];
        }
        else if (other.tag == "Base")
        {
            target = targetFlag;
        }
    }
    private void TeamIdentify()
    {
        if (SaveData.redBlue)
        {
            this.gameObject.tag = "CharacterBlue";
            enemy.tag = "CharacterBlue";
            i = 1;
            targetBase[i].tag = "Base";
        }
        else
        {
            this.gameObject.tag = "CharacterRed";
            enemy.tag = "CharacterRed";
            i = 0;
            targetBase[i].tag = "Base";
            baseLvl.transform.Rotate(0, 0, -180);
        }
    }
}
