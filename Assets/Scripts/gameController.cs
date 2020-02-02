using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class ConsoleData
{
    [SerializeField]
    private string id = "";
    [SerializeField]
    private bool unlocked = false;

    public ConsoleData(string id, bool unlocked)
    {
        this.id = id;
        this.unlocked = unlocked;
    }

    public void setUnlock(bool unlocked)
    {
        this.unlocked = unlocked;
    }

    public string getId()
    {
        return this.id;
    }

    public bool getUnlock()
    {
        return this.unlocked;
    }
}

public class gameController : MonoBehaviour
{
    [SerializeField]
    private GameObject consoleTextBox;

    [SerializeField]
    private bool enableConsole = false;

    [SerializeField]
    private string[] consoleId = new string[] {
        "right_button_move",
        "left_movement_method",
        "up_trigger_enable",
        "down_button_true",
        "interaction_triggered",
        "npc_dialogue=true",
        "obj_door=unlock",
        "npc_greg=true",
        "enable_collider=false",
        "npc_evilking.pos_x=100,pos_y=100"
    };

    [SerializeField]
    private List<ConsoleData> consoleDataList = new List<ConsoleData>();

    [SerializeField]
    private bool devPanelEnabled = false;
    [SerializeField]
    private GameObject devPanel;
    [SerializeField]
    private GameObject helpText;

    private void init()
    {   
        // Create the console data.
        foreach(string item in this.consoleId)
        {
            this.consoleDataList.Add(new ConsoleData(item, false));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        init();
        this.consoleTextBox.transform.gameObject.SetActive(enableConsole);
        this.devPanel.SetActive(this.devPanelEnabled);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tilde) || Input.GetKeyDown(KeyCode.BackQuote))
        {
            this.triggerConsoleBox();
        }


        this.devPanelController();
    }

    // trigger the console box.
    public void triggerConsoleBox()
    {
        enableConsole = !enableConsole;
        this.consoleTextBox.transform.gameObject.SetActive(enableConsole);
    }

    // check if input already unlock.
    public bool isConsoleUnlock(string inputText)
    {
        bool result = false;

        foreach(ConsoleData item in this.consoleDataList)
        {
            if(item.getId() == inputText.Trim((char)8203) && item.getUnlock())
            {
                result = true;
            }
        }

        return result;
    }
    
    // Code unlock.
    public int unlockCode(string inputText)
    {
        int result = 0;

        foreach (ConsoleData item in this.consoleDataList)
        {
            if (item.getId() == inputText.Trim((char)8203) && !item.getUnlock())
            {
                item.setUnlock(true);
                result = 1;
            }

            else if (item.getId() == inputText.Trim((char)8203) && item.getUnlock())
            {
                result = 2;
            }

            if(inputText.Trim((char)8203) == "npc_evilking.pos_x=100,pos_y=100")
            {
                SceneManager.LoadScene("endGame", LoadSceneMode.Single);
            }

        }

        return result;
    }

    private void devPanelController()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            string result = "";
            foreach (ConsoleData item in this.consoleDataList)
            {
                result += item.getId() + ": " + item.getUnlock() + "\n";
            }
                this.helpText.GetComponent<UnityEngine.UI.Text>().text = result;

            this.devPanelEnabled = !this.devPanelEnabled;
            this.devPanel.SetActive(this.devPanelEnabled);
        }
    }
}
