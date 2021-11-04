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
    public Transform parent;
    private int item = 0;
    private float skillRollTime = 15f;
    private bool timerOn = false;
    private Vector3 position;

    private void Update()
    {
        if (timerOn)
        {
            skillRollTime -= Time.deltaTime;
            Timer(skillRollTime);
        }
    }
    public void SetBarriers()
    {
        timerOn = true;
        item = Random.Range(0, listBarriers.Count);
        GameObject obj = parent.GetChild(item).gameObject;
        obj.SetActive(true);
        obj.transform.position = character.transform.position;
        obj.transform.localRotation = character.transform.localRotation;
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
