using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractionOld : MonoBehaviour
{
    float speed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xpos = Input.GetAxis("Horizontal");
        float ypos = Input.GetAxis("Vertical");


        Vector3 newpos = new Vector3(ypos, -xpos, 0);

        transform.Rotate(newpos * speed * Time.deltaTime,Space.World);
    }
}
