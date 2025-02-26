using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    private void Start()
    {
        runtoggle.gameObject.SetActive(false);
        Joystick.gameObject.SetActive(false);
        jumpbutton.gameObject.SetActive(false);
    }
    // Update is called once per frame
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasjumped = true;
        }

        if (hasjumped)
        {
            goup = true;
            Jump();
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
            float height = Mathf.Lerp(1.05f, 2.05f, t);
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
            float height = Mathf.Lerp(2.05f, 1.05f, t);
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
        while(transform.position.y < 2.05)
        {
            t += Time.deltaTime * 10;
            float height = Mathf.Lerp(1.05f, 2.05f, t);
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
            if (t >= 1)
            {
                t = 0;
            }
        }
        while(transform.position.y > 1.05)
        {
            t += Time.deltaTime * 10;
            float height = Mathf.Lerp(2.05f, 1.05f, t);
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
            if (t >= 1)
            {
                t = 0;
            }
        }
    }
}
