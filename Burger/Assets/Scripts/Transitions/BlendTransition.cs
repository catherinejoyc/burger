using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlendTransition : MonoBehaviour
{
    [SerializeField]
    private Image blackImage;

    // Start is called before the first frame update
    public void StartBlendOutTransition()
    {
        StartCoroutine(BlendOutTransition());
    }

    IEnumerator BlendOutTransition()
    {       
        float alpha = 1;
        blackImage.color = new Color(0,0,0,alpha);

        while (alpha > 0)
        {
            alpha -= 0.01f;
            blackImage.color = new Color(0, 0, 0, alpha);
            yield return new WaitForFixedUpdate();
        }
    }
}
