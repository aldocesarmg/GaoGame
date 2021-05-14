using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floorScroller : MonoBehaviour
{
    public Rigidbody2D rb;

    private float width;
    private float scrollSpeed = -4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        width = GetComponent<SpriteRenderer>().bounds.size.x;

        rb.velocity = new Vector2(scrollSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -(1.5f * width)) //transform.position.x < -width
        {
            Vector2 resetPosition = new Vector2(width * 3f - 0.01f, 0);
            transform.position = (Vector2)transform.position + resetPosition;
        }
    }
}
