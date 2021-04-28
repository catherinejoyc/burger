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
    private float musicVolume = 0.1f;
    public bool overworld = false;
    public bool fightscene = false;
    public bool gameOver = false;

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

        if(instance == null)
        {
            instance = this;
        }
        
    }

    private void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }
    private void Update()
    {

        audioSrc.volume = musicVolume;
        if (SceneManager.GetActiveScene().buildIndex == 1 && !overworld && !fightscene)
        {
            overworld = true;
            fightscene = false;
            PlayOverworldClip();

        }
        else if (SceneManager.GetActiveScene().buildIndex == 5 && !gameOver)
        {
            gameOver = true;
            PlayOverworldClip();
        }
    }

    public void PlayFightClip()
    {
        if (fightscene)
            return;

        fightscene = false;
        audioSrc.clip = FightClip;
        audioSrc.Play();
    }

    public void PlayFullClip()
    {
        audioSrc.clip = FightClip;
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
