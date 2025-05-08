using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    float xInput;
    float yInput;
    int score = 0; // The gamer score
    public int winScore; // Max score in the level
    public GameObject winText; // Referance to the text

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y < -5f)
        {
            SceneManager.LoadScene("Level_1");
        }

        // Yeni Input System ile input okuma
        xInput = 0f;
        yInput = 0f;

        if (Keyboard.current != null)
        {
            if (Keyboard.current.aKey.isPressed) xInput = -1f;
            if (Keyboard.current.dKey.isPressed) xInput = 1f;
            if (Keyboard.current.wKey.isPressed) yInput = 1f;
            if (Keyboard.current.sKey.isPressed) yInput = -1f;
        }
    }

    private void FixedUpdate()
    {
        rb.AddForce(xInput * speed, 0, yInput * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            other.gameObject.SetActive(false);  // Hide the coin
            score++; // add 1 to score

            if(score>=winScore)
            {
                winText.SetActive(true);
            }
        }
    }
}
