using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class SkillRollback : MonoBehaviour
{
    [SerializeField] private Text timer;
    [SerializeField] private Button buttonLeap;
    [SerializeField] private ParticleSystem[] leapParticle;
    [SerializeField] private GameObject[] leapParticleObject;
    [SerializeField] private Animator buttonBlink;
    [SerializeField] private UnityEvent leapForward;
    private float skillRollTime = 15f;
    private bool timerOn = false;
    private int i;
    private void Awake()
    {
        ParticleColorIdent();
        leapParticle[i].Stop(true);
    }
    private void Update()
    {
        if (timerOn)
        {
            skillRollTime -= Time.deltaTime;
            Timer(skillRollTime);
        }
    }
    private void Timer(float totalSeconds)
    {
        buttonBlink.enabled = false;
        buttonLeap.interactable = false;
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);
        if (seconds <= 0)
        {
            buttonLeap.interactable = true;
            timer.enabled = true;
            buttonBlink.enabled = true;
            timerOn = false;
            timer.text = "";
            skillRollTime = 15f;
        }
        timer.text = seconds.ToString("00");
        if (timer.text == "00")
        {
            timer.text = "";
        }
    }
    public void ParticlePlay()
    {
        leapParticle[i].Play(true);
        StartCoroutine(ParticleOff());
        timerOn = true;
        leapForward.Invoke();
    }
    private void ParticleColorIdent()
    {
        if (SaveData.redBlue)
        {
            i = 0;
            leapParticleObject[i].SetActive(true);
        }
        else
        {
            i = 1;
            leapParticleObject[i].SetActive(true);
        }
    }
    private IEnumerator ParticleOff()
    {
        yield return new WaitForSeconds(1);
        leapParticle[i].Stop(true);
    }
}
