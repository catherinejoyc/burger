using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialTransition : MonoBehaviour
{
    [SerializeField]
    private Image blackImage;

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
    }
}
