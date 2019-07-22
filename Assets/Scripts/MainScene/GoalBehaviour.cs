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
    public GameObject gameOverPanel;

    public AudioClip scoreSound;
    public AudioClip winSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ball")
        {
            mainCamera.GetComponent<ScreenShaker>().StartCoroutine("Shake", 0.5);
            scoreParticles.Play();
            score++;
            playerScoreText.text = score.ToString();
            collision.GetComponent<BallMovement>().StartCoroutine("Reset");

            if (score >= maxScore)
            {
                SoundControllerBehaviour.instance.PlayFxVariant(winSound);
                winnerText.GetComponent<Animator>().SetTrigger("Win");
                StartCoroutine("GameOver");
            }
            else
            {
                SoundControllerBehaviour.instance.PlayFxVariant(scoreSound);
                collision.GetComponent<BallMovement>().StartCoroutine("Launch");
            }
        }
    }

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        gameOverPanel.SetActive(true);
    }
}
