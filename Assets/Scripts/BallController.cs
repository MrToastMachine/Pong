using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody2D rb;
    private GameObject player;
    private GameObject enemy;

    public float speed = 6f;
    public float angleScale = 3f;

    public AudioClip Pop;
    public AudioClip Oof;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        rb = GetComponent<Rigidbody2D>();

        float initialX = Random.Range(-10f, 10f);
        float initialY = Random.Range(-5f, 5f);
        rb.velocity = new Vector2(initialX, initialY).normalized*speed;

        audioSource.clip = Pop;
    }
    IEnumerator Delay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("RightZone"))
        {
            //Debug.Log("You Win");
            Destroy(gameObject);
        } else if (collision.gameObject.tag.Equals("LeftZone"))
        {
            audioSource.clip = Oof;
            audioSource.Play();
            Delay(2);
            //Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.Play();
        float contactPos;
        //Debug.Log(collision.GetContact(0).point);
        if (collision.gameObject.Equals(player))
        {
            contactPos = collision.GetContact(0).point.y;
            contactPos -= player.transform.position.y;
            Debug.Log("Dist from player centre: " + contactPos);
            rb.velocity = new Vector2(speed, contactPos * angleScale).normalized * speed;
        }
        else if (collision.gameObject.Equals(enemy))
        {
            contactPos = collision.GetContact(0).point.y;
            contactPos -= enemy.transform.position.y;
            Debug.Log("Dist from enemy centre: " + contactPos);
            rb.velocity = new Vector2(-speed, contactPos * angleScale).normalized * speed;
        }
    }
}
