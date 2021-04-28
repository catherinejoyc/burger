using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareTime : MonoBehaviour
{
    // Start is called before the first frame update
    private const string TWITTER_ADDRESS = "https://www.facebook.com/dialog/feed?";
    private const string TWEET_LANGUAGE = "en";
    public static string descriptionParam;
    private string appStoreLink = "http://www.gamelink.com";
    public float time;
    public int score;
    public void ShareToTW(string linkParameter)
    {

        string nameParameter = "I finished Burger in " + time.ToString() + " seconds and scored a total of " + score.ToString() + "!";//this is limited in text length 
        Application.OpenURL(TWITTER_ADDRESS + "&href=" + WWW.EscapeURL(appStoreLink) +
           "?text" + WWW.EscapeURL(nameParameter + "\n" + descriptionParam + "\n" + "Get the Game:\n" + appStoreLink));
    }
}
