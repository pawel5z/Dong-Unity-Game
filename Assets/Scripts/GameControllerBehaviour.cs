using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerBehaviour : MonoBehaviour
{
    public GameObject gameOverPanel;

    public IEnumerator GameOver()
    {
        yield return new WaitForSeconds(3);
        gameOverPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
