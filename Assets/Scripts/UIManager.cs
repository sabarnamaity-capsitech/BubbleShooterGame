using UnityEngine;

public class UIManager : MonoBehaviour
{
     public static UIManager Instance;

    public GameObject startPanel;
  //  public GameObject gamePanel;

    private void Awake()
    {
        Instance = this;
    }

    public void PlayGame()
    {
        startPanel.SetActive(false);
        // gamePanel.SetActive(true);
        // GameManager.Instance.StartGame();
        GridManager.Instance.GenerateGrid();
        ShooterController.Instance.LoadBubble();
    }
}
