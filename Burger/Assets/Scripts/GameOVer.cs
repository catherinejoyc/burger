using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOVer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.PlayOverworldClip();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
