using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class consoleTextBox : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI TextInputBox;

    [SerializeField]
    private GameObject controller;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            string textInput = this.TextInputBox.text;
            this.unlockInput(textInput);

            this.controller.GetComponent<gameController>().triggerConsoleBox();
        }
    }

    private void unlockInput(string inputText)
    {
        int result = this.controller.GetComponent<gameController>().unlockCode(inputText);
        Debug.Log(result);
        // Trigger sound depends on unlocking type. 0 no code found, 1 new unlocked, 2 already unlocked
    }


    private void checkInput(string inputText)
    {
        bool result = this.controller.GetComponent<gameController>().isConsoleUnlock(inputText);
        Debug.Log(result);
    }
}
