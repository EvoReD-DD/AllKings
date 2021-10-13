using UnityEngine;
using UnityEngine.UI;

public class BlueBase : MonoBehaviour
{
    [SerializeField] private Text bluePoint;
    [SerializeField] private GameObject flag;
    private FlagController flagController;
    private int pointWeight = 1;
    private int pointBlue;
    private void Start()
    {
        flagController = flag.GetComponent<FlagController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CharacterBlue" && other.GetComponentInChildren<FlagController>() != null)
        {
            var pointText = System.Convert.ToInt32(bluePoint.text);
            pointBlue = pointText + pointWeight;
            bluePoint.text = pointBlue.ToString();
            flagController.ResetFlag();
        }
    }
}
