using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class npc2 : MonoBehaviour
{

    [SerializeField]
    private GameObject gameController;

    [SerializeField]
    private TextMeshPro TextInputBox;

    private void Start()
    {
        this.gameController = GameObject.FindGameObjectWithTag("GameController");
    }


    // Check if code is unlock
    private bool isCodeUnlock(string textInput)
    {
        return this.gameController.GetComponent<gameController>().isConsoleUnlock(textInput);
    }


    public void interact()
    {
        if (this.isCodeUnlock("npc_dialogue=true"))
        {
            TextInputBox.SetText("Nice day for a fishing...");
        } else
        {
            TextInputBox.SetText("// Remember to enable dialogue with npc_dialogue=true");
        }
        
        StartCoroutine(this.Countdown(5));
    }

    private void hideChat()
    {
        TextInputBox.SetText("");
    }

    private IEnumerator Countdown(int seconds)
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
        }
        this.hideChat();
    }
}
