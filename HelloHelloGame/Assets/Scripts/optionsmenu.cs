        using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class optionsmenu : MonoBehaviour
{
    public AudioMixer audiomixer,soundeffectmixer;

    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("volume", volume);
    }                       

    public void SetVolume1(float volume)
    {
        Debug.Log("changing sfx volume");
       soundeffectmixer.SetFloat("soundeffectvolume", volume);
    }
}
