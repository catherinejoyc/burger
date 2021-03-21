using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogsystem : MonoBehaviour
{
    public static Dialogsystem instance;

    [SerializeField]
    private GameObject dialogPanel;
    [SerializeField]
    private Text dialog;
    public Image face;

    public bool isSpeaking {get{return speaking != null;}}
    [HideInInspector] public bool isWaitingForUserInput = false;

    private void Awake()
    {
        instance = this;
    }

    public void Say(string speech)
    {
        StopSpeaking();
        speaking = StartCoroutine(Speaking(speech));
    }

    Coroutine speaking = null;
    IEnumerator Speaking(string speech)
    {
        dialogPanel.SetActive(true);
        dialog.text = "";
        isWaitingForUserInput = false;

        while (dialog.text != speech)
        {
            dialog.text += speech[dialog.text.Length];
            yield return new WaitForFixedUpdate();
        }

        isWaitingForUserInput = true;
        while(isWaitingForUserInput)
        {
            yield return new WaitForFixedUpdate();
        }

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
