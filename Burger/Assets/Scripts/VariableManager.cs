using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VariableManager : MonoBehaviour
{
    int playerIndex; //1 Vik, 2 Tam, 3 Dor
    bool playerIsSet = false;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerIsSet && SceneManager.GetActiveScene().buildIndex == 1)
        {
            playerIsSet = true;
            GameManager.Instance.EnableCharacter(playerIndex);
            print("Spawn " + playerIndex);
        }
    }

    public void SetPlayerIndex(int i)
    {
        playerIndex = i;
    }
}
