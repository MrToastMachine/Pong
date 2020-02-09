using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 movement = Vector2.zero;
    public float speed = 0.6f;

    public float yLimit = 3.8f;

    float mousePos = 0f;
    float mouseMargin = 0.02f;

    void Update()
    {
        //if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && transform.position.y < yLimit)
        //{
        //    transform.Translate(new Vector2(0, speed * Time.deltaTime));
        //}
        //else if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && transform.position.y > -yLimit)
        //{
        //    transform.Translate(new Vector2(0, -speed * Time.deltaTime));
        //}

        

        Vector2 mouse = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 point;
        point = Camera.main.ScreenToWorldPoint(mouse);

        if (point.y > transform.position.y)
        {
            mousePos = 1f;
        }
        else
        {
            mousePos = -1f;
        }
        
        float distToMouse = point.y - transform.position.y;
        
        ////////////////////////////////////////
        if (mousePos > 0 && transform.position.y < yLimit && Mathf.Abs(distToMouse) > mouseMargin)
        {
            transform.Translate(new Vector2(0, mousePos * speed * Time.deltaTime));
        }
        else if (mousePos < 0 && transform.position.y > -yLimit && Mathf.Abs(distToMouse) > mouseMargin)
        {
            transform.Translate(new Vector2(0, mousePos * speed * Time.deltaTime));
        }

    }
}
