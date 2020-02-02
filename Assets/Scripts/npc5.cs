using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class npc5 : MonoBehaviour
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
        TextInputBox.SetText("I heard npc_evilking is very strong! He live in the dungeon at 'pos_x=100,pos_y=100'. Good thing we are at npc_kenneth.'pos_x=0,pos_y=0'");
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
