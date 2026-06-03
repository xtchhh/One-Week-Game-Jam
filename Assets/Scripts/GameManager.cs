using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GameOverUI()
    {
        SceneManager.LoadScene("GameOverScreen");
    }

    public void SecondGameOverUI()
    {
        SceneManager.LoadScene("GameOverScreen2");
    }
}
