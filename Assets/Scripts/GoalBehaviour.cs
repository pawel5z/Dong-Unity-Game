using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalBehaviour : MonoBehaviour
{
    public int score = 0;
    public Text playerScoreText;
    public ParticleSystem scoreParticles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            scoreParticles.Play();
            collision.GetComponent<BallMovement>().StartCoroutine("Reset");
            collision.GetComponent<BallMovement>().StartCoroutine("Launch");
            score++;
            playerScoreText.text = score.ToString();
        }
    }
}
