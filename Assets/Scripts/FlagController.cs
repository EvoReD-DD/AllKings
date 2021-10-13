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
    private void Start()
    {
        this.transform.position = startPosition;
        this.transform.rotation = startRotation;
    }
    public void ResetFlag()
    {
        this.gameObject.transform.SetParent(null);
        this.transform.position = Vector3.zero;
        this.transform.rotation = Quaternion.Euler(0, -90, 0); ;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CharacterRed")
        {
            this.transform.SetParent(other.transform);
            this.transform.localPosition = Vector3.zero;
            this.transform.localPosition = flagPositionInPlayer;
            this.transform.localRotation = flagRotationsInPlayer;
            HitEventRed.Invoke();
        }
        else if (other.tag == "CharacterBlue")
        {
            this.transform.SetParent(other.transform);
            this.transform.localPosition = Vector3.zero;
            this.transform.localPosition = flagPositionInPlayer;
            this.transform.localRotation = flagRotationsInPlayer;
            HitEventBlue.Invoke();
        }
    }
}
