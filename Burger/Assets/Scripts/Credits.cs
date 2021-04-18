using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public Slider progressBar;
    public Text savedToText;

    public void Download()
    {
        WebClient webClient = new WebClient();
        webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
        webClient.DownloadFileAsync(new Uri("https://cdn.discordapp.com/attachments/833394647932993537/833395026507202640/Dives_-_Burger_320.mp3"), Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Dives-Burger.mp3");
    }
    private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        progressBar.value = e.ProgressPercentage;
    }


    private void Completed(object sender, AsyncCompletedEventArgs e)
    {
        savedToText.text = "Download complete! Saved to: " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/Dives-Burger.mp3";
    }
}
