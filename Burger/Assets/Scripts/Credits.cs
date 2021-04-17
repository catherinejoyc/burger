using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public void Download()
    {
        WebClient webClient = new WebClient();
        webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
        webClient.DownloadFileAsync(new Uri("https://catherinejoyc.github.io/portfolio/assets/images/123.jpg"), @"D:\123.jpg");
    }

    private void Completed(object sender, AsyncCompletedEventArgs e)
    {
        print("Download completed!");
    }
}
