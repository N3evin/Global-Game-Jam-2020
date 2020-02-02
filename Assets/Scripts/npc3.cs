using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class npc3 : MonoBehaviour
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
        TextInputBox.SetText("Thanks for finding obj_key, npc_greg is looking for you at the orange house.");
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
