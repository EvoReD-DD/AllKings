using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class FlagController : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Quaternion startRotation;
    [SerializeField] private UnityEvent HitEventBlue;
    [SerializeField] private UnityEvent HitEventRed;
    [SerializeField] private Vector3 flagPositionInPlayer;
    [SerializeField] private Quaternion flagRotationsInPlayer;
    [SerializeField] private ParticleSystem hitFlagParticle;
    private bool onTake = true;
    private void Start()
    {
        this.transform.position = startPosition;
        this.transform.rotation = startRotation;
        hitFlagParticle.Stop(true);
    }
    public void ResetFlag()
    {
        this.gameObject.transform.SetParent(null);
        this.transform.position = Vector3.zero;
        this.transform.rotation = Quaternion.Euler(0, -90, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "CharacterRed")
        {
            if (onTake)
            {
                FlagTakeRed(other);
                onTake = false;
                hitFlagParticle.Play(true);
                EnemyAI.TargetUpdate();
                StartCoroutine(TakeFlagPause(other));
            }
        }
        else if (other.tag == "CharacterBlue")
        {
            if (onTake)
            {
                FlagTakeBlue(other);
                onTake = false;
                hitFlagParticle.Play(true);
                EnemyAI.TargetUpdate();
                StartCoroutine(TakeFlagPause(other));
            }
        }
    }
    IEnumerator TakeFlagPause(Collider other)
    {
        yield return new WaitForSeconds(0.5f);
        onTake = true;
    }
    private void FlagTakeRed(Collider other)
    {
        this.transform.SetParent(other.transform);
        this.transform.localPosition = Vector3.zero;
        this.transform.localPosition = flagPositionInPlayer;
        this.transform.localRotation = flagRotationsInPlayer;
        HitEventRed.Invoke();
    }
    private void FlagTakeBlue(Collider other)
    {
        this.transform.SetParent(other.transform);
        this.transform.localPosition = Vector3.zero;
        this.transform.localPosition = flagPositionInPlayer;
        this.transform.localRotation = flagRotationsInPlayer;
        HitEventBlue.Invoke();
    }

}
