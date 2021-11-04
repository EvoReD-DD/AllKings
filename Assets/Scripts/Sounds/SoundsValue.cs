using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SoundsValue : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup mixerMaster;
    [SerializeField] private AudioMixerGroup mixerUI;
    [SerializeField] private AudioMixerGroup mixerMusic;
    [SerializeField] private AudioMixerSnapshot snapNormal;
    [SerializeField] private AudioMixerSnapshot snapInPause;
    [SerializeField] private AudioMixerSnapshot snapMute;
    [SerializeField] private Toggle muteToggle;

    private void Start()
    {
        snapNormal.TransitionTo(0);
    }
    public void MasterVolume(float volume)
    {
        mixerMaster.audioMixer.SetFloat("Master", Mathf.Log10(volume)*20);
    }
    public void UIVolume(float volume)
    {
       mixerMaster.audioMixer.SetFloat("UI", Mathf.Log10(volume) * 20);
    }
    public void MusicVolume(float volume)
    {
       mixerMaster.audioMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }
    public void SoundInPause()
    {
        snapInPause.TransitionTo(0);
    }
    public void SoundOutPause()
    {
        snapNormal.TransitionTo(0);
    }
    public void SoundMute()
    {
        if (!muteToggle.isOn)
        {
            snapMute.TransitionTo(0);
        }
        else
        {
            snapNormal.TransitionTo(0);
        }
    }
}
