using UnityEngine;
using UnityEngine.Events;

public class FlagTakeAway : MonoBehaviour
{
    [SerializeField] private GameObject flag;
    [SerializeField] private UnityEvent HitEventBlue;
    [SerializeField] private UnityEvent HitEventRed;
    [SerializeField] private Vector3 flagPositionInPlayer;
    [SerializeField] private Quaternion flagRotationsInPlayer;

    private void OnTriggerEnter(Collider other)
    {
        /*if (other.tag == "CharacterRed" )
        {
            Debug.Log("WorkThisCodeSecond");
            flag.transform.SetParent(other.transform);
            flag.transform.localPosition = Vector3.zero;
            flag.transform.localPosition = flagPositionInPlayer;
            flag.transform.localRotation = flagRotationsInPlayer;
        }
        else if (other.tag == "CharacterBlue")
        {
            Debug.Log("WorkThisCodeSecond");
            flag.transform.SetParent(other.transform);
            flag.transform.localPosition = Vector3.zero;
            flag.transform.localPosition = flagPositionInPlayer;
            flag.transform.localRotation = flagRotationsInPlayer;
        }*/
    }
   }
