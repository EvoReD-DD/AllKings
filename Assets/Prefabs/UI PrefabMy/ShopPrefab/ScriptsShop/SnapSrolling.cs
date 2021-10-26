using UnityEngine;

public class SnapSrolling : MonoBehaviour
{
    [Header("Controllers")]
    [Range(1, 20)]
    [SerializeField] private int countPan;
    [Range(20, 300)]
    [SerializeField] private int panOffset;
    [Header("Objects")]
    [SerializeField] private GameObject scrollPanPrefab;
    private GameObject[] instPans;

    private void Start()
    {

        instPans = new GameObject[countPan];
        for (int i = 0; i < countPan; i++)
        {
            instPans[i] = Instantiate(scrollPanPrefab, this.transform, false);
        }
    }
}
