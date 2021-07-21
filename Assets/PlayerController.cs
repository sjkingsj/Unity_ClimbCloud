using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigid2D; // For use Rigidbody 2D
    Animator animator;
    float jumpForce = 680.0f; // Force of Jump
    float walkForce = 30.0f;  // Force of Walk
    float maxWalkSpeed = 2.0f;   // Max Speed of Walk
    float threshold = 0.2f; // Min Value of Accelration Sensor

    // Start is called before the first frame update
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>(); // Get Component to rigid2D for use AddForce Method
        this.animator = GetComponent<Animator>(); // Get Component to animator for adjust animation
    }

    // Update is called once per frame
    void Update()
    {
        // Jump if Push Space bar or Touch the Screen
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space) && this.rigid2D.velocity.y == 0) // Make not to jump if player jumping
        {
            this.animator.SetTrigger("JumpTrigger"); // Initiate Jump Tigger Animation
            this.rigid2D.AddForce(transform.up * this.jumpForce); // Jump as much as Upside Vector of 1 length * jumpForce
        }

        // Move of X Axis
        int key = 0; // Set key to 0, so that it does not move when notihng is pressed
        if (Input.GetKey(KeyCode.RightArrow)) key = 1; // Set key to 1 when right
        if (Input.GetKey(KeyCode.LeftArrow)) key = -1; // Set key to -1 when left
        //if (Input.acceleration.x > this.threshold) key = 1; // Set key to 1 when tilt right
        //if (Input.acceleration.x < this.threshold) key = -1; // Set key to -1 when tilt left

        // Speed of Player
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);

        // Limit of Speed
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce); // Acceleration
        }

        // Reverse Sprite depending on direction of movement
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1); // Set 1 or -1 Scale of X axis of Sprite depending on direction of movement
        }

        // Change Player's Animation Speed as Player's Speed
        if (this.rigid2D.velocity.y == 0)
        {
            this.animator.speed = speedx / 2.0f; // Set Animation Speed while Walk
        }
        else
        {
            this.animator.speed = 1.0f; // Fix Animation Speed while Jump
        }

        // Go to First Scene if Player get out of screen
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    // Arrive At Flag
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Goal");
        SceneManager.LoadScene("ClearScene");
    }
}
