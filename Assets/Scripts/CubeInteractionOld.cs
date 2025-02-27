using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class CubeInteractionOld : MonoBehaviour
{
    Vector3 mpos;
    Vector3 newpos;
    Vector3 cubesize;
    float xpos;
    float ypos;
    public bool onkeyboard;
    public bool onmobile;
    public bool onmouse;

    private void Start()
    {
        cubesize = transform.localScale;
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
        if (Input.touchCount > 0)
        {
            if (Input.touchCount == 1)
            {
                float speed = 10f;
                Touch touch = Input.GetTouch(0);

                Vector2 startingpos = touch.position - touch.deltaPosition;
                float dist = Vector2.Distance(startingpos, touch.position);
                float rotthr = 50f;

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

                float startingdist = 0;
                float currentdist = 0;
                float distdiff = 0;


                if(touch1.phase == TouchPhase.Began && touch2.phase == TouchPhase.Began)
                {
                    startingdist = Vector2.Distance(touch1.position, touch2.position);
                }

                if(touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
                {
                    currentdist = Vector2.Distance(touch1.position, touch2.position);
                    distdiff = currentdist - startingdist;

                    if(Mathf.Abs(distdiff) < 5)
                    {
                        MoveCube(touch1, touch2);
                    }
                    else
                    {
                        ZoomCube(touch1, touch2, distdiff);
                    }
                }
            }
        }
    }

    void MoveCube(Touch touch1, Touch touch2)
    {
        float x = (touch1.deltaPosition.x + touch2.deltaPosition.x) / 2;
        float y = (touch1.deltaPosition.y + touch2.deltaPosition.y) / 2;

        Vector3 newpos = new Vector3(x, y, 0);
        transform.position += newpos * Time.deltaTime;
    }

    void ZoomCube(Touch touch1, Touch touch2, float distdiff)
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