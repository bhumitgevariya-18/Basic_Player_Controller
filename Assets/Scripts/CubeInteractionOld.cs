using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractionOld : MonoBehaviour
{
    float speed = 50f;
    Vector3 mpos;
    float xpos;
    float ypos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xpos = Input.GetAxis("Horizontal");
        ypos = Input.GetAxis("Vertical");

        if (Input.GetMouseButton(0))
        {
            xpos = Input.GetAxis("Mouse X");
            ypos = Input.GetAxis("Mouse Y");
        }

        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            Vector2 touchpos = Input.GetTouch(0).deltaPosition;
            
            if (touchpos.x < 0.0f)
            {
                transform.Translate(Vector3.left * 10 * Time.deltaTime);
            }
            else if (touchpos.x > 0.0f)
            {
                transform.Translate(Vector3.right * 10 * Time.deltaTime);
            }

        }

        Vector3 newpos = new Vector3(ypos, -xpos, 0);

        transform.Rotate(newpos * speed * Time.deltaTime,Space.World);

        if (Input.GetMouseButtonDown(1))
        {
            mpos = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        }
        if (Input.GetMouseButton(1))
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mpos);
        }
    }
}
