using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<Dialog>().enabled = true;

            gameManager.WinTransGSEvent.AddListener(DeactivateEnemy);

            gameManager.DialogGSEvent.Invoke();
        }
    }

    void DeactivateEnemy()
    {
        gameManager.WinTransGSEvent.RemoveListener(DeactivateEnemy);

        GetComponentInParent<GameObject>().SetActive(false);        
    }
}
