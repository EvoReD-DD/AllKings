using UnityEngine;
using UnityEngine.UI;

public class RedBase : MonoBehaviour
{
    [SerializeField] private Text redPoint;
    [SerializeField] private GameObject flag;
    private FlagController flagController;
    private int pointWeight = 1;
    private int pointRed;
    private void Start()
    {
        flagController = flag.GetComponent<FlagController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CharacterRed" && other.GetComponentInChildren<FlagController>() != null)
        {
            var pointText = System.Convert.ToInt32(redPoint.text);
            pointRed = pointText + pointWeight;
            redPoint.text = pointRed.ToString();
            flagController.ResetFlag();
        }
    }
}
