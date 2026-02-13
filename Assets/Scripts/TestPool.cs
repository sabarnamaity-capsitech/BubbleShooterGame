using UnityEngine;

public class TestPool : MonoBehaviour
{
    public BubbleDatabase database;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnBubble();
        }
    }

    void SpawnBubble()
    {
        Bubble b = BubblePool.Instance.GetBubble();
        if (b == null) return;

        BubbleData data = database.GetRandomBubble();
        b.Setup(data);

        b.transform.position = new Vector2(0, 0);
    }
}
