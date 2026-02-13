using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score;

    private void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        score = 0;

      //  GridManager.Instance.GenerateGrid();
       // ShooterController.Instance.LoadNextBubble();
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }
}
