using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovementOld : MonoBehaviour
{
    float speed;
    public Toggle runtoggle;
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
            speed = 5f;
        }
        float xpos = Input.GetAxis("Horizontal");
        float ypos = Input.GetAxis("Vertical");
        
        Vector3 newpos = new Vector3(xpos,0,ypos);

        transform.position += newpos * speed * Time.deltaTime;
    }
}
