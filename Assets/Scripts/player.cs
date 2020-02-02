using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField]
    private GameObject gameController;

    [SerializeField]
    private float MovementSpeed;

    [SerializeField]
    private Vector2 playerDirection;

    [SerializeField]
    private Sprite playerUp;
    [SerializeField]
    private Sprite playerDown;
    [SerializeField]
    private Sprite playerLeft;
    [SerializeField]
    private Sprite playerRight;

    [SerializeField]
    private GameObject hitObject = null;


    // Update is called once per frame
    void Update()
    {
        Vector3 direction = CalculateDirection();
        transform.Translate(direction * MovementSpeed * Time.deltaTime);
    }

    private Vector3 CalculateDirection()
    {
        Vector3 direction = Vector3.zero;
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && this.isCodeUnlock("up_trigger_enable"))
        {
            direction.y += 1.0f;
            this.GetComponent<SpriteRenderer>().sprite = this.playerUp;
            this.playerDirection = Vector2.up;
        }
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && this.isCodeUnlock("left_movement_method"))
        {
            direction.x -= 1.0f;
            this.GetComponent<SpriteRenderer>().sprite = this.playerLeft;
            this.playerDirection = Vector2.left;
        }
        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && this.isCodeUnlock("down_button_true"))
        {
            direction.y -= 1.0f;
            this.GetComponent<SpriteRenderer>().sprite = this.playerDown;
            this.playerDirection = Vector2.down;
        }
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && this.isCodeUnlock("right_button_move"))
        {
            direction.x += 1.0f;
            this.GetComponent<SpriteRenderer>().sprite = this.playerRight;
            this.playerDirection = -Vector2.left;
        }

        this.interactionController();

        return direction.normalized;
    }

    // Collider system.
    void FixedUpdate()
    {
        LayerMask layerMask = ~(1 << LayerMask.NameToLayer("TransparentFX"));

        RaycastHit2D hit = Physics2D.Raycast(transform.position, this.playerDirection, 3, layerMask);
        if (hit.collider != null)
        {
            this.hitObject = hit.collider.gameObject;
        } else
        {
            this.hitObject = null;
        }
    }


    // Check if code is unlock
    private bool isCodeUnlock(string textInput)
    {
        return this.gameController.GetComponent<gameController>().isConsoleUnlock(textInput);
    }

    // Interaction related stuff.
    private void interactionController()
    {
        if (Input.GetKey(KeyCode.E) && this.isCodeUnlock("interaction_triggered"))
        {
            if (this.hitObject != null)
            {
                if (this.hitObject.tag == "ExitDoor")
                {
                    this.hitObject.GetComponent<exitDoor>().interact(this.gameObject);
                }

                if (this.hitObject.name == "NPC_1")
                {
                    this.hitObject.GetComponent<npc>().interact();
                }

                if (this.hitObject.name == "NPC_2")
                {
                    this.hitObject.GetComponent<npc2>().interact();
                }

                if (this.hitObject.name == "NPC_3")
                {
                    this.hitObject.GetComponent<npc3>().interact();
                }

                if (this.hitObject.name == "NPC_4")
                {
                    this.hitObject.GetComponent<npc4>().interact();
                }

                if (this.hitObject.name == "NPC_5")
                {
                    this.hitObject.GetComponent<npc5>().interact();
                }
            }
        }
    }
}
