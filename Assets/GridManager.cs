using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager Instance;
    private bool gridGenerated = false;

    public int rows = 5;
    public int columns = 10;

    public float bubbleSize = 1f;   // must match sprite scale
    public Vector2 startPosition = new Vector2(-2.2f, 4f);

    public BubbleDatabase database;

    private void Awake()
    {
        Instance = this;
    }

    public void GenerateGrid()
    {
        if (gridGenerated) return;   // prevents double spawn

        gridGenerated = true;

        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                SpawnBubble(row, col);
                Debug.Log("Grid Generated1");
            }
        }

        Debug.Log("Grid Generated Successfully");
    }


  
    void SpawnBubble(int row, int col)
    {
        Bubble b = BubblePool.Instance.GetBubble();
        if (b == null) return;

        BubbleData data = database.GetRandomBubble();
        b.Setup(data);

        Vector3 position = new Vector3(
            startPosition.x + col * bubbleSize,
            startPosition.y - row * bubbleSize,
            0f
        );

        b.transform.SetParent(transform);
        b.transform.position = position;
    }

}
