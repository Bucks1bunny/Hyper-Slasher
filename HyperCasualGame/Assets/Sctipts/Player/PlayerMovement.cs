using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float sideSpeed;

    private Rigidbody rb;
    private float width;
    private Touch touch;

    private void Awake()
    {
        width = (float)Screen.width / 2.0f;

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
                MoveToSide(Vector3.right);
            }
            else if (pos.x < 0)
            {
                MoveToSide(Vector3.left);
            }
        }
    }

    private void MoveToSide(Vector3 direction)
    {
        transform.Translate(direction * sideSpeed * Time.deltaTime);
    }
}
