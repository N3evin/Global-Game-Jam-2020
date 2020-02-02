using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class npc4 : MonoBehaviour
{

    [SerializeField]
    private GameObject gameController;

    [SerializeField]
    private TextMeshPro TextInputBox;

    [SerializeField]
    private bool isSpriteHidden = false;

    private void Start()
    {   
        this.gameController = GameObject.FindGameObjectWithTag("GameController");
        gameObject.GetComponent<Renderer>().enabled = this.isSpriteHidden;

    }

    private void FixedUpdate()
    {
        if (this.isCodeUnlock("npc_greg=true"))
        {
            this.isSpriteHidden = true;
            gameObject.GetComponent<Renderer>().enabled = this.isSpriteHidden;
        }
    }


    // Check if code is unlock
    private bool isCodeUnlock(string textInput)
    {
        return this.gameController.GetComponent<gameController>().isConsoleUnlock(textInput);
    }


    public void interact()
    {
        if (this.isSpriteHidden)
        {
            TextInputBox.SetText("Day 3 of dev: Nevin, added the collider for 4th house, I was wondering why I could not enter the house to test. Had to enable collider to `false`.");
            StartCoroutine(this.Countdown(5));
        }
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
