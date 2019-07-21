using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoalBehaviour : MonoBehaviour
{
    private int score = 0;
    public Text playerScoreText;
    public ParticleSystem scoreParticles;
    public Text winnerText;
    public int maxScore;
    public GameObject gameController;
    public GameObject mainCamera;

    public AudioClip scoreSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            SoundControllerBehaviour.instance.PlayFxVariant(scoreSound);
            mainCamera.GetComponent<ScreenShaker>().StartCoroutine("Shake", 0.5);
            scoreParticles.Play();
            score++;
            playerScoreText.text = score.ToString();
            collision.GetComponent<BallMovement>().StartCoroutine("Reset");

            if (score >= maxScore)
            {
                winnerText.GetComponent<Animator>().SetTrigger("Win");
                gameController.GetComponent<GameControllerBehaviour>().StartCoroutine("GameOver");
            }
            else
                collision.GetComponent<BallMovement>().StartCoroutine("Launch");
        }
    }
}
