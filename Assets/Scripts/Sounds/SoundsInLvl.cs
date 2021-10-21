using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsInLvl : MonoBehaviour
{
    [SerializeField] private AudioSource soundFX;
    private void Start()
    {
        SoundVolume();
    }
    private void SoundVolume()
    {
        soundFX.volume = 0.3f;
    }
}
