using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialTransition : MonoBehaviour
{
    public Image blackImage;
    bool transitionIsActive = false;
    GameManager gameManager;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void StartTransition()
    {
        if (!transitionIsActive)
        {
            StartCoroutine(Transition());
            print("Start Transition");
        }        
    }

    IEnumerator Transition()
    {
        transitionIsActive = true;
        blackImage.fillAmount = 0;

        while (blackImage.fillAmount < 1)
        {
            blackImage.fillAmount += 0.01f;
            yield return new WaitForFixedUpdate();
        }

        //activate Fight panel etc.
        gameManager.currentGameState = GameState.Fight;
        gameManager.battleSystem.fightBox.SetActive(true);
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
            alpha -= 0.02f;
            blackImage.color = new Color(0, 0, 0, alpha);
            yield return new WaitForFixedUpdate();
        }

        transitionIsActive = false;
        print("transitionIsActive = " + transitionIsActive);
    }
}
