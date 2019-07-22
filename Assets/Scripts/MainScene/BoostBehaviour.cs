using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBehaviour : MonoBehaviour
{
    public float verticalVelocity;
    public GameObject effectCarrier;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, verticalVelocity);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "BoostsMotionField")
            Destroy(gameObject);
    }
}
