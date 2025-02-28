using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovementOld : MonoBehaviour
{
    float speed;
    float t;
    public Toggle runtoggle;
    public Button jumpbutton;
    float xpos;
    float ypos;
    bool goup = false;
    bool godown = false;
    bool hasjumped = false;
    public Joystick Joystick;
    public bool keyboard;
    public bool joystick;
    float h;

    private void Start()
    {
        h = transform.position.y;

        runtoggle.gameObject.SetActive(false);
        Joystick.gameObject.SetActive(false);
        jumpbutton.gameObject.SetActive(false);
        jumpbutton.onClick.AddListener(ButtonJump);
    }

    void Update()
    {
        if (keyboard)
        {
            KeyboardIP();
        }

        if (joystick)
        {
            JoystickIP();
        }

        Vector3 newpos = new Vector3(xpos, 0, ypos);
        transform.position += newpos * speed * Time.deltaTime;

        if (hasjumped)
        {
            Jump();
        }
    }

    public void KeyboardIP()
    {
        xpos = Input.GetAxis("Horizontal");
        ypos = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.R))
        {
            Run();
        }
        else
        {
            Walk();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !hasjumped)
        {
            hasjumped = true;
            goup = true;
        }
    }

    public void JoystickIP()
    {
        runtoggle.gameObject.SetActive(true);
        Joystick.gameObject.SetActive(true);
        jumpbutton.gameObject.SetActive(true);

        xpos = Joystick.Horizontal;
        ypos = Joystick.Vertical;

        if (runtoggle.isOn)
        {
            speed = 10f;
        }
        else
        {
            speed = 3f;
        }

    }
    public void Jump()
    {
        if (goup)
        {
            t += Time.deltaTime * 10;
            float height = Mathf.Lerp(h, h + 1, t);
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
            if (t >= 1)
            {
                t = 0;
                goup = false;
                godown = true;
            }
        }
        else if (godown)
        {
            t += Time.deltaTime * 10;
            float height = Mathf.Lerp(h + 1, h, t);
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
            if (t >= 1)
            {
                t = 0;
                godown = false;
                hasjumped = false;
            }
        }
    }
    public void Run()
    {
        speed = 10f;
    }

    public void Walk()
    {
        speed = 3f;
    }

    public void ButtonJump()
    {
        if (!hasjumped)
        {
            hasjumped = true;
            goup = true;
        }
    }
}