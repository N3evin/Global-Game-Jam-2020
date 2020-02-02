using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalBlock : MonoBehaviour
{

    [SerializeField]
    private GameObject gameController;

    [SerializeField]
    private bool isEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        this.gameController = GameObject.FindGameObjectWithTag("GameController");
        this.gameObject.SetActive(true);
    }

    // Check if code is unlock
    private bool isCodeUnlock(string textInput)
    {
        return this.gameController.GetComponent<gameController>().isConsoleUnlock(textInput);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.isCodeUnlock("enable_collider=false"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
