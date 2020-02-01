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
            this.playerDirection = -Vector2.up;
        }
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && this.isCodeUnlock("right_button_move"))
        {
            direction.x += 1.0f;
            this.GetComponent<SpriteRenderer>().sprite = this.playerRight;
            this.playerDirection = -Vector2.left;
        }
        return direction.normalized;
    }

    // Collider system.
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, this.playerDirection, 1);
        if (hit.collider != null) {
            print(hit.collider.gameObject.name);
        }
    }


    // Check if code is unlock
    private bool isCodeUnlock(string textInput)
    {
        return this.gameController.GetComponent<gameController>().isConsoleUnlock(textInput);
    }
}
