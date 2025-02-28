using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CubeInteractionOld : MonoBehaviour
{
    Vector3 mpos;
    Vector3 newpos;
    Vector3 cubesize;

    float xpos;
    float ypos;
    float min;
    float max;
    public bool onkeyboard;
    public bool onmobile;
    public bool onmouse;

    private void Start()
    {
        cubesize = transform.localScale;
        float min = cubesize.x;
        float max = min + 3;
    }
    // Update is called once per frame
    void Update()
    {
        if (onkeyboard)
        {
            KeyboardIP();
        }

        if (onmouse)
        {
            MouseIP();
        }

        if (onmobile)
        {
            MobileIP();
        }
    }

    void KeyboardIP()
    {
        float speed = 50f;
        xpos = Input.GetAxis("Horizontal");
        ypos = Input.GetAxis("Vertical");

        newpos = new Vector3(ypos, -xpos, 0);
        transform.Rotate(newpos * speed * Time.deltaTime, Space.World);
    }

    void MouseIP()
    {
        float speed = 50f;
        if (Input.GetMouseButton(0))
        {
            xpos = Input.GetAxis("Mouse X");
            ypos = Input.GetAxis("Mouse Y");
        }

        newpos = new Vector3(ypos, -xpos, 0);
        transform.Rotate(newpos * speed * Time.deltaTime, Space.World);

        if (Input.GetMouseButtonDown(1))
        {
            mpos = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        }
        if (Input.GetMouseButton(1))
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mpos);
        }

    }

    void MobileIP()
    {
        if (Input.touchCount == 1)
        {
            float speed = 10f;
            Touch touch = Input.GetTouch(0);

            Vector2 startingpos = touch.position - touch.deltaPosition;
            float dist = Vector2.Distance(startingpos, touch.position);
            float rotthr = 30f;

            if (dist >= rotthr)
            {
                xpos = touch.deltaPosition.x;
                ypos = touch.deltaPosition.y;
                newpos = new Vector3(ypos, -xpos, 0);
                transform.Rotate(newpos * speed * Time.deltaTime, Space.World);
            }
        }
        else if (Input.touchCount == 2)
        {
            Touch touch1 = Input.GetTouch(0);
            Touch touch2 = Input.GetTouch(1);

            Vector2 startingpost1 = touch1.position - touch1.deltaPosition;
            Vector2 startingpost2 = touch2.position - touch2.deltaPosition;

            float startingdist = Vector2.Distance(startingpost1, startingpost2);
            float currentdist = Vector2.Distance(touch1.position, touch2.position);

            float distdiff = currentdist - startingdist;
            float movethr = 5f;
            float zoomthr = 30f;
            float check = Mathf.Abs(distdiff);
            if (check > movethr && check < zoomthr)
            {
                float x = (touch1.deltaPosition.x + touch2.deltaPosition.x) / 2;
                float y = (touch1.deltaPosition.y + touch2.deltaPosition.y) / 2;
                
                Vector3 newpos = new Vector3(x, y, 0);
                transform.position += newpos * Time.deltaTime; 
            }
            else if (check > zoomthr)
            {
                float min = cubesize.x;
                float max = min + 3;

                float zoom = distdiff / 100;

                Vector3 size = transform.localScale + new Vector3(zoom, zoom, zoom);

                size.x = Mathf.Clamp(size.x, min, max);
                size.y = Mathf.Clamp(size.y, min, max);
                size.z = Mathf.Clamp(size.z, min, max);

                transform.localScale = size;
            }
        }
    }
}