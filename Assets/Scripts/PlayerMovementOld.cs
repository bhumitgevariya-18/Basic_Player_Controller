using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementOld : MonoBehaviour
{
    float speed;
    public Toggle runtoggle;
    float t;
    bool goup = false;
    bool godown = false;
    bool hasjumped = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (runtoggle.isOn)
        {
            speed = 20f;
        }
        else
        {
            speed = 3f;
        }

        float xpos = Input.GetAxis("Horizontal");
        float ypos = Input.GetAxis("Vertical");

        Vector3 newpos = new Vector3(xpos, 0, ypos);

        transform.position += newpos * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasjumped = true;
            goup = true;
        }
        if (hasjumped)
        {
            Jump();
        }
    }
    void Jump()
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
}
