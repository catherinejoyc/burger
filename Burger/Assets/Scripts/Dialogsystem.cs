using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogsystem : MonoBehaviour
{
    [SerializeField]
    private Text dialog;
    Coroutine speaking = null;
    public bool isSpeaking
    {
        get
        {
            return speaking != null;
        }
    }
    public void Say(string speech)
    {
        StopSpeaking();

        speaking = StartCoroutine(Speaking(speech));
    }
    IEnumerator Speaking(string speech)
    {
        dialog.text = "";

        while (dialog.text != speech)
        {
            dialog.text += speech[dialog.text.Length];
            yield return new WaitForFixedUpdate();
        }
        
        yield return new WaitForSeconds(3);

        StopSpeaking();
    }

    public void StopSpeaking()
    {
        if (isSpeaking)
        {
            StopCoroutine(speaking);
        }
        speaking = null;
    }
}
