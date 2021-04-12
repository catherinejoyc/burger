using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSrc;
    public AudioClip FightClip;
    public AudioClip FullClip;
    public AudioClip OverworldClip;
    private float musicVolume = 1f;
    public bool overworld = false;

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
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        
    }

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    private void Update()
    {
        audioSrc.volume = musicVolume;
        if (SceneManager.GetActiveScene().buildIndex == 2 && overworld == false)
        {
            overworld = true;
            PlayOverworldClip();

        }
    }

    public void PlayFightClip()
    {
        audioSrc.clip = FightClip;
    }

    public void PlayFullClip()
    {
        audioSrc.clip = FullClip;
    }

    public void PlayOverworldClip()
    {
        audioSrc.clip = OverworldClip;
        audioSrc.Play();
    }

    public void SetVolume(float vol)
    {
        musicVolume = vol;
    }
}
