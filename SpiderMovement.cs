using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector3 direction;

    void Update()
    {
        float horizontalAxis = Input.GetAxis("Horizontal");
        float verticalAxis = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalAxis, 0, verticalAxis).normalized * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, horizontalAxis, 0));
    }
}
