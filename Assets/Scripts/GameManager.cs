using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void GameOverUI()
    {
        SceneManager.LoadScene("GameOverScreen");
    }
}
