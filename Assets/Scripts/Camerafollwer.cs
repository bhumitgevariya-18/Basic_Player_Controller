using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    public float speed = 5f;

    private void Start()
    {
        offset = Camera.main.transform.position;
    }
    void LateUpdate()
    {
        if (target == null)
        {
            Debug.Log("Attach target to follow");
        }

        Vector3 campos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, campos, speed * Time.deltaTime);
        transform.LookAt(target);
    }
}
