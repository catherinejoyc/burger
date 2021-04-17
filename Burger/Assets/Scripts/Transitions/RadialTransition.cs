using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialTransition : MonoBehaviour
{
    [SerializeField]
    private Image blackImage;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void StartTransition()
    {
        StartCoroutine(Transition());
    }

    IEnumerator Transition()
    {
        blackImage.fillAmount = 0;

        while (blackImage.fillAmount < 1)
        {
            blackImage.fillAmount += 0.01f;
            yield return new WaitForFixedUpdate();
        }

        //activate Fight panel etc.
        gameManager.currentGameState = GameState.Fight;
        gameManager.battleSystem.fightPanel.SetActive(true);

        StartBlendOutTransition();
    }

    public void StartBlendOutTransition()
    {
        StartCoroutine(BlendOutTransition());
    }

    IEnumerator BlendOutTransition()
    {
        float alpha = 1;
        blackImage.color = new Color(0, 0, 0, alpha);

        while (alpha > 0)
        {
            alpha -= 0.01f;
            blackImage.color = new Color(0, 0, 0, alpha);
            yield return new WaitForFixedUpdate();
        }
    }
}
