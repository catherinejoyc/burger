using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource AudioSrc;
    public AudioClip FightClip;

    private static AudioManager instance;
    public static AudioManager Instance
    {
        get
        {
            return instance;
        }
        set
        {
            if (instance == null)
            {
                instance = value;
            }
            else
            {
                Debug.LogError("Audio Manager exists already!");
            }
        }
    }

    public void PlayFightClip()
    {
        AudioSrc.clip = FightClip;
    }
}
