using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiBehavior : MonoBehaviour
{
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(4f, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyBehavior enemy = collision.GetComponent<enemyBehavior>();
        if (enemy != null)
        {
            enemy.Die();
        }

        Destroy(gameObject);
    }
}
