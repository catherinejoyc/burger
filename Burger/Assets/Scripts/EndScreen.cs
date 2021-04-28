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
        end.SetActive(false);
        photo.SetActive(false);
    }
    public void CallEnd()
    {
        photo.SetActive(true);
        end.SetActive(true);
        scorescreen.SetActive(false);
    }
}
