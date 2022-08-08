using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float sideSpeed;
    private Rigidbody rb;
    private float width;
    private Vector3 position;
    private Touch touch;

    private void Awake()
    {
        width = (float)Screen.width / 2.0f;
        position = new Vector3(0.0f, 0.0f, 0.0f);

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        rb.velocity = transform.forward * speed;

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            Vector2 pos = touch.position;
            pos.x = (pos.x - width) / width;

            Mathf.Clamp(pos.x, -0.5f, 0.5f);
            if (pos.x > 0)
            {
                transform.Translate(Vector3.right * sideSpeed * Time.deltaTime);
            }
            else if (pos.x < 0)
            {
                transform.Translate(Vector3.left * sideSpeed * Time.deltaTime);
            }
        }
    }
}
