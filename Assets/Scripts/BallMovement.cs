using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float initSpeed;
    private float speed;
    private readonly List<float> rngPosNegList = new List<float> { -1, 1 };
    private Rigidbody2D rb2d;
    private int bounceCount = 0;

    // Start is called before the first frame update
    private void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        speed = initSpeed;

        StartCoroutine("Launch");
    }

    public IEnumerator Launch()
    {
        yield return new WaitForSeconds(2);
        float angleRad = Random.Range(3, 7) * 15 * Mathf.Deg2Rad;
        rb2d.velocity = new Vector2(initSpeed * Mathf.Sin(angleRad) * rngPosNegList[Random.Range(0, rngPosNegList.Count)], initSpeed * Mathf.Cos(angleRad) * rngPosNegList[Random.Range(0, rngPosNegList.Count)]);
        yield return null;
    }

    public IEnumerator Reset()
    {
        yield return new WaitForSeconds(1);
        this.GetComponentInChildren<TrailRenderer>().emitting = false;
        this.transform.position = new Vector2(0, 0);
        this.rb2d.velocity = new Vector2(0, 0);
        this.speed = initSpeed;
        this.bounceCount = 0;
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boundary")
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -1 * rb2d.velocity.y);
        }
        else if (collision.tag == "Player")
        {
            this.GetComponentInChildren<ParticleSystem>().Play();
            float diff = this.transform.position.y - collision.transform.position.y;
            float sgn = Mathf.Sign(diff);
            float intDiff = Mathf.Clamp(Mathf.Floor(diff * sgn), 0, 3);
            float angleRad = 15 * intDiff * Mathf.Deg2Rad;
            float xDirSgn = Mathf.Sign(rb2d.velocity.x);
            float speedMult = 1 + (intDiff / 6);

            speed = initSpeed + 3 * Mathf.Log(2 + bounceCount, 2);
            rb2d.velocity = new Vector2(-1 * xDirSgn * speed * speedMult * Mathf.Cos(angleRad), sgn * speed * speedMult * Mathf.Sin(angleRad));
            bounceCount++;

            if (intDiff == 3)
                this.GetComponentInChildren<TrailRenderer>().emitting = true;
            else
                this.GetComponentInChildren<TrailRenderer>().emitting = false;
        }
    }
}
