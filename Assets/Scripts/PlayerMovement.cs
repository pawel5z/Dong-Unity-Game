using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public string verticalAxisName;
    public float speed;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Input.GetAxis(verticalAxisName) * speed);
    }
}
