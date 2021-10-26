using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;

public class SetBarrier : MonoBehaviour
{
    [SerializeField] private List<GameObject> listBarriers;
    [SerializeField] private Text timer;
    [SerializeField] private Button buttonBarrier;
    [SerializeField] private Animator buttonBlink;
    [SerializeField] private GameObject character;
    [SerializeField] private Vector3 offsetIstantiate;
    private int item = 0;
    private float skillRollTime = 15f;
    private bool timerOn = false;

    private void Update()
    {
        if (timerOn)
        {
            skillRollTime -= Time.deltaTime;
            Timer(skillRollTime);
        }
    }
    public void SetDistance()
    {
       
    }
    public void SetBarriers()
    {
        timerOn = true;
        item = Random.Range(0, listBarriers.Count);
        Instantiate(listBarriers[item], character.transform.position - offsetIstantiate , Quaternion.identity);
    }
    private void Timer(float totalSeconds)
    {
        buttonBlink.enabled = false;
        buttonBarrier.interactable = false;
        int seconds = Mathf.RoundToInt(totalSeconds % 60f);
        if (seconds <= 0)
        {
            buttonBarrier.interactable = true;
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
}
