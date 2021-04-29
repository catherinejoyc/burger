using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    private static Credits instance;
    public static Credits Instance
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
                Debug.LogError("Credits exists already!");
            }
        }
    }

    private void Awake()
    {
        instance = this;
    }

    public Slider progressBar;
    public Text savedToText;
    public GameObject downloadSlider;
    public Text timeTxt;
    public Text scoreTxt;
    public ShareTime shareTime;

    private void Start()
    {
        downloadSlider.SetActive(false);
    }
    public void Download()
    {
        downloadSlider.SetActive(true);
        WebClient webClient = new WebClient();
        webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
        webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/833394647932993537/833395026507202640/Dives_-_Burger_320.mp3"), Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Dives - Burger.mp3");
    }
    private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        progressBar.value = e.ProgressPercentage;
    }

    private void Completed(object sender, AsyncCompletedEventArgs e)
    {
        savedToText.text = "Download complete! Saved to: " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Dives-Burger.mp3";
    }

    public void UpdateScore(int time, int score)
    {
        timeTxt.text = "Time: " + time.ToString();
        scoreTxt.text = "Score: " + score.ToString();
        shareTime.time = time;
        shareTime.score = score;
    }
}
