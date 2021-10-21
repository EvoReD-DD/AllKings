using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioSource soundFX;
    [SerializeField] private AudioClip click;
    [SerializeField] private AudioClip clickExit;
    [SerializeField] private AudioClip backgroundMenu;
    [SerializeField] private AudioClip error;
    [SerializeField] private GameObject errorNickName;
    [SerializeField] private AudioClip slider;

    
    public void ClickSound()
    {
        soundFX.PlayOneShot(click);
    }
    public void ClickExitSound()
    {
        soundFX.PlayOneShot(clickExit);
    }
    public void OnBackgroundMusic()
    {
        soundFX.PlayOneShot(backgroundMenu);
    }
    public void ErrorSound()
    {
        if (errorNickName.activeSelf)
        {
            soundFX.PlayOneShot(error);
        }
    }
    public void SliderSound()
    {
        soundFX.PlayOneShot(slider);
    }
    public void SoundsOff()
    {
        soundFX.mute = !soundFX.mute;
    }
}
