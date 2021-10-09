using UnityEngine;
using UnityEngine.Events;

public class FlagController : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Quaternion startRotation;
    [SerializeField] private UnityEvent HitEventBlue;
    [SerializeField] private UnityEvent HitEventRed;
    [SerializeField] private Vector3 flagPositionInPlayer;
    [SerializeField] private Quaternion flagRotationsInPlayer;
    private bool parentOn = false;
    void Start()
    {
        this.transform.position = startPosition;
        this.transform.rotation = startRotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (parentOn == false)
        {
            if (other.tag == "CharacterRed")
            {
                parentOn = true;
                this.transform.SetParent(other.transform);
                this.transform.localPosition = Vector3.zero;
                this.transform.localPosition = flagPositionInPlayer;
                this.transform.localRotation = flagRotationsInPlayer;
                HitEventRed.Invoke();
            }
            else if (other.tag == "CharacterBlue")
            {
                parentOn = true;
                this.transform.SetParent(other.transform);
                this.transform.localPosition = Vector3.zero;
                this.transform.localPosition = flagPositionInPlayer;
                this.transform.localRotation = flagRotationsInPlayer;
                HitEventBlue.Invoke();
            }
        }
    }
}
