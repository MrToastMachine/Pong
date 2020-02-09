using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    private GameObject ball;

    public float speed = 4f;
    public float yLimit = 3.8f;
    // Start is called before the first frame update
    void Start()
    {
        //ball = FindObjectOfType(typeof(BallController));
        ball = GameObject.FindGameObjectWithTag("Ball");
    }

    // Update is called once per frame
    void Update()
    {
        if (ball && Mathf.Abs(ball.transform.position.y - transform.position.y)>0.05)
        {
            float ballPosY = Mathf.Sign(ball.transform.position.y - transform.position.y);
            if (ballPosY > 0 && transform.position.y < yLimit)
            {
                transform.Translate(new Vector2(0, ballPosY * speed * Time.deltaTime));
            } else if(ballPosY < 0 && transform.position.y > -yLimit)
            {
                transform.Translate(new Vector2(0, ballPosY * speed * Time.deltaTime));
            }
        }
    }
}
