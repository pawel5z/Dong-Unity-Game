using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public string verticalAxisName;
    public float speed;

    private Rigidbody2D rb2d;
    private float xPosSgn;

    // Start is called before the first frame update
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        xPosSgn = Mathf.Sign(transform.position.x);
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, Input.GetAxis(verticalAxisName) * speed);
    }

    public void Reset()
    {
        transform.position = new Vector2(35 * xPosSgn, transform.position.y);
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
    }

    public void SuddenDeath()
    {
        rb2d.velocity = new Vector2(xPosSgn * -1 * 0.5f, rb2d.velocity.y);
    }
}
