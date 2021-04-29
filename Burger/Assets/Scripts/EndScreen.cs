using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject end;
    public GameObject scorescreen;
    public GameObject photo;

    private void Start()
    {
        end.SetActive(true);
        photo.SetActive(true);
        scorescreen.SetActive(true);
        scorescreen.GetComponent<Canvas>().enabled = false;
    }
    public void CallEnd()
    {
        photo.SetActive(false);
        end.SetActive(false);
        scorescreen.GetComponent<Canvas>().enabled = true;
    }
}
