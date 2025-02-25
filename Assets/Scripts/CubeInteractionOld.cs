using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractionOld : MonoBehaviour
{
    float speed = 50f;
    Vector3 mpos;
    float xpos;
    float ypos;
    float zoomSpeed = 0.1f;
    float minZoom = 2f;
    float maxZoom = 15f;

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

        if (Input.GetMouseButtonDown(1))
        {
            mpos = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        }
        if (Input.GetMouseButton(1))
        {
            transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mpos);
        }

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (Input.touchCount == 1)
            {
                if (touch.phase == TouchPhase.Moved)
                {
                    xpos = touch.deltaPosition.x;
                    ypos = touch.deltaPosition.y;
                }
            }
        }

        Vector3 newpos = new Vector3(ypos, -xpos, 0);

        transform.Rotate(newpos * speed * Time.deltaTime, Space.World);
    }
}
























//            // **Two Touches - Move & Zoom**
//            else if (Input.touchCount == 2)
//            {
//                Touch touch1 = Input.GetTouch(0);
//                Touch touch2 = Input.GetTouch(1);

//                // **Move with two fingers**
//                if (touch1.phase == TouchPhase.Moved && touch2.phase == TouchPhase.Moved)
//                {
//                    Vector2 avgDelta = (touch1.deltaPosition + touch2.deltaPosition) / 2;
//                    Vector3 move = new Vector3(avgDelta.x, avgDelta.y, 0) * Time.deltaTime;
//                    transform.position += move;
//                }

//                // **Zoom with pinch gesture (Limited)**
//                float prevDistance = (touch1.position - touch1.deltaPosition - (touch2.position - touch2.deltaPosition)).magnitude;
//                float currentDistance = (touch1.position - touch2.position).magnitude;
//                float deltaDistance = currentDistance - prevDistance;

//                if (Mathf.Abs(deltaDistance) > 0.1f)
//                {
//                    float newZoom = Camera.main.transform.position.z + deltaDistance * zoomSpeed;
//                    newZoom = Mathf.Clamp(newZoom, -maxZoom, -minZoom); // Limit zoom
//                    Camera.main.transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, newZoom);
//                }
//            }
//        }
//    }
//}

