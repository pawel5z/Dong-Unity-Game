using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float initSpeed;
    public GameObject suddenDeathController;
    public float timeToSuddenDeath;
    public GameObject boostsController;

    private float speed;
    private readonly List<float> rngPosNegList = new List<float> { -1, 1 };
    private Rigidbody2D rb2d;
    private int bounceCount = 0;
    private float timeWithoutGoal = 0;
    private GameObject lastPlayerHit;

    // Start is called before the first frame update
    private void Start()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        speed = initSpeed;

        StartCoroutine("Launch");
    }

    private IEnumerator SuddenDeathTimer()
    {
        timeWithoutGoal = 0;
        while(timeWithoutGoal < timeToSuddenDeath)
        {
            yield return new WaitForSeconds(1);
            timeWithoutGoal += 1;
            if (timeWithoutGoal >= timeToSuddenDeath)
                suddenDeathController.GetComponent<SuddenDeathControllerBehaviour>().StartSuddenDeath();
        }
    }

    public IEnumerator Launch()
    {
        boostsController.GetComponent<BoostsControllerBehaviour>().StartCoroutine("Work");
        yield return new WaitForSeconds(2);
        StartCoroutine("SuddenDeathTimer");
        float angleRad = Random.Range(3, 7) * 15 * Mathf.Deg2Rad;
        rb2d.velocity = new Vector2(initSpeed * Mathf.Sin(angleRad) * rngPosNegList[Random.Range(0, rngPosNegList.Count)], initSpeed * Mathf.Cos(angleRad) * rngPosNegList[Random.Range(0, rngPosNegList.Count)]);
        yield return null;
    }

    public IEnumerator Reset()
    {
        boostsController.GetComponent<BoostsControllerBehaviour>().ClearBoosts();
        boostsController.GetComponent<BoostsControllerBehaviour>().StopCoroutine("Work");
        StopCoroutine("SuddenDeathTimer");
        suddenDeathController.GetComponent<SuddenDeathControllerBehaviour>().StopSuddenDeath();
        yield return new WaitForSeconds(1);
        GetComponentInChildren<TrailRenderer>().emitting = false;
        transform.position = new Vector2(0, 0);
        rb2d.velocity = new Vector2(0, 0);
        speed = initSpeed;
        bounceCount = 0;
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Boundary")
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -1 * rb2d.velocity.y);
        }
        else if (collision.tag == "Player")
        {
            lastPlayerHit = collision.gameObject;
            GetComponentInChildren<ParticleSystem>().Play();
            float diff = transform.position.y - collision.transform.position.y;
            float sgn = Mathf.Sign(diff);
            float intDiff = Mathf.Clamp(Mathf.Floor(diff * sgn), 0, 3);
            float angleRad = 15 * intDiff * Mathf.Deg2Rad;
            float xDirSgn = Mathf.Sign(rb2d.velocity.x);
            float speedMult = 1 + (intDiff / 6);

            speed = initSpeed + 3 * Mathf.Log(2 + bounceCount, 2);
            rb2d.velocity = new Vector2(-1 * xDirSgn * speed * speedMult * Mathf.Cos(angleRad), sgn * speed * speedMult * Mathf.Sin(angleRad));
            bounceCount++;

            if (intDiff == 3)
                GetComponentInChildren<TrailRenderer>().emitting = true;
            else
                GetComponentInChildren<TrailRenderer>().emitting = false;
        }
        else if (collision.tag == "Boost")
        {
            Instantiate(collision.gameObject.GetComponent<BoostBehaviour>().effectCarrier, lastPlayerHit.transform);
            Destroy(collision.gameObject);
        }
    }
}
