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
}
