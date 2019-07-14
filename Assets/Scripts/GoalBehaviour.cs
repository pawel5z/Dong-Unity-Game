﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            collision.GetComponent<BallMovement>().StartCoroutine("Reset");
            collision.GetComponent<BallMovement>().StartCoroutine("Launch");
        }
    }
}