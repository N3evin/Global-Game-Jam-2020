using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class npc : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> waypoints;

    [SerializeField]
    private float speed = 3;

    [SerializeField]
    private int currentWaypoint  = 0;

    [SerializeField]
    private bool isWalking = true;

    [SerializeField]
    private GameObject gameController;

    [SerializeField]
    private TextMeshPro TextInputBox;

    private void Start()
    {
        this.gameController = GameObject.FindGameObjectWithTag("GameController");
    }

    private void Update()
    {
        if (isWalking)
        {
            this.walking();
        }
    }

    private void walking()
    {

        // Walking
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, this.waypoints[this.currentWaypoint].transform.position, step);

        if (Vector3.Distance(transform.position, this.waypoints[this.currentWaypoint].transform.position) < 1.0f) {

            if(this.currentWaypoint >= this.waypoints.Count-1)
            {
                this.currentWaypoint = 0;
            } else
            {
                this.currentWaypoint++;
            }
        }
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
            TextInputBox.SetText("Oh no! I Lost my obj_key! Now I can't obj_door=unlock my house.");
        } else
        {
            TextInputBox.SetText("Errorz NPC Dialogue Missing!");
        }
        
        this.isWalking = false;
        StartCoroutine(this.Countdown(5));
    }

    private void restoreWalking()
    {
        this.isWalking = true;
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
        this.restoreWalking();
    }
}
