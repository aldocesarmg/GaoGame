using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyBehavior : MonoBehaviour
{
    public int damage = 1;
    public float speed = -4f;

    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-4f, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //COLLISION AGAINST THE PLAYER
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //collision.GetComponent<Player>().health -= damage;
            Destroy(gameObject);
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
