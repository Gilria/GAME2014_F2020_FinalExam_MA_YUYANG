using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlateformController : MonoBehaviour
{
    float moveSpeed = 1;
    float startYpos;

    private PlayerBehaviour player;

    

    void Start()
    {
        startYpos = transform.position.y;
        player = FindObjectOfType<PlayerBehaviour>();
    }

    
    void Update()
    {
        if (transform.localScale.x <= 0)
        {
            Invoke("_Reset", 1f);
        }
        _Move();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player" && player.transform.position.y > transform.position.y)
        {
            MySoundController.PlaySound("Shrinking");
            StopAllCoroutines();
            StartCoroutine(SetSize(0));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            MySoundController.PlaySound("Resetting");
            StopAllCoroutines();
            StartCoroutine(SetSize(1));
        }
    }

    void _Reset()
    {
        StopAllCoroutines();
        StartCoroutine(SetSize(1));
    }


    void _Move()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        if (transform.position.y > startYpos + 10 || transform.position.y < startYpos)
        {
            moveSpeed = -moveSpeed;
        }
    }


    IEnumerator SetSize(float xScale)
    {
        float startXscale = transform.localScale.x;
        float duration = 2f;
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / duration;
            transform.localScale = new Vector2(Mathf.Lerp(startXscale, xScale, t), 1);
            yield return 0;
        }
    }
}
