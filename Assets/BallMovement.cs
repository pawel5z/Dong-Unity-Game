using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float initSpeed;
    private float speed;

    private readonly List<float> rngPosNegList = new List<float> { -1, 1 };
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    private void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        speed = initSpeed;

        Launch();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void Launch()
    {
        float angleRad = Random.Range(3, 7) * 15 * Mathf.Deg2Rad;
        rb2d.velocity = new Vector2(initSpeed * Mathf.Sin(angleRad) * rngPosNegList[Random.Range(0, rngPosNegList.Count)], initSpeed * Mathf.Cos(angleRad) * rngPosNegList[Random.Range(0, rngPosNegList.Count)]);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boundary")
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -1 * rb2d.velocity.y);
        }
        else if (collision.tag == "Player")
        {
            float diff = this.transform.position.y - collision.transform.position.y;
            float sgn = Mathf.Sign(diff);
            float mult = Mathf.Clamp(Mathf.Floor(diff * sgn), 0, 3);
            float angleRad = 15 * mult * Mathf.Deg2Rad;
            float xDirSgn = Mathf.Sign(rb2d.velocity.x);

            rb2d.velocity = new Vector2(-1 * xDirSgn * speed * Mathf.Cos(angleRad), sgn * speed * Mathf.Sin(angleRad));
        }
    }
}
