using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitDoor : MonoBehaviour
{
    [SerializeField]
    private GameObject exitObject;

    [SerializeField]
    private GameObject gameController;

    [SerializeField]
    private bool doorCodeRequire = false;


    private void Start()
    {
        this.gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    public void interact(GameObject player)
    {
        if (!doorCodeRequire || (this.isCodeUnlock("obj_door=unlock") && doorCodeRequire))
        {
            player.transform.position = exitObject.transform.position;
        }
    }

    // Check if code is unlock
    private bool isCodeUnlock(string textInput)
    {
        return this.gameController.GetComponent<gameController>().isConsoleUnlock(textInput);
    }
}
