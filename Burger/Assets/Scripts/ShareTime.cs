using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShareTime : MonoBehaviour
{
    // Start is called before the first frame update
    private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
    private const string TWEET_LANGUAGE = "en";
    public static string descriptionParam;
    private string gameLink = "https://kinayastudios.itch.io/the-legend-of-dives-mortal-burger-kombat";
    private string divesInsta = "https://www.instagram.com/dives_vienna/";
    private string divesFb = "https://www.facebook.com/DIVESvienna";
    public float time = 144f;
    public int score = 7;
    public void ShareToTW(string linkParameter)
    {

        string nameParameter = "I finished 'The Legend of DIVES: Mortal Burger Kombat' in " + time.ToString() + " seconds, with a score of " + score.ToString() + "!";//this is limited in text length 
        Application.OpenURL(TWITTER_ADDRESS +
           "?text=" + WWW.EscapeURL(nameParameter + "\n" + descriptionParam + "\n" + "Play the game here:\n" + gameLink + "\n\nCheck out DIVES:" + "\n" + divesInsta + "\n" + divesFb));
    }

}
