﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class optionsmenu : MonoBehaviour
{
    public AudioMixer audiomixer;
    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("volume", volume);
    }
}