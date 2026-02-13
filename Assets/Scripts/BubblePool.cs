using UnityEngine;
using System.Collections.Generic;

public class BubblePool : MonoBehaviour
{
    public static BubblePool Instance;

    public Bubble bubblePrefab;
    public int poolSize = 50;

    private Queue<Bubble> pool = new Queue<Bubble>();

    private void Awake()
    {
        Instance = this;

        CreatePool();
    }

    void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            Bubble b = Instantiate(bubblePrefab);
            b.gameObject.SetActive(false);
            pool.Enqueue(b);
        }
    }

    public Bubble GetBubble()
    {
        if (pool.Count == 0)
        {
            Debug.Log("Pool Empty!");
            return null;
        }

        Bubble b = pool.Dequeue();
        b.gameObject.SetActive(true);
        b.ResetBubble();

        return b;
    }

    public void ReturnBubble(Bubble b)
    {
        b.gameObject.SetActive(false);
        pool.Enqueue(b);
    }
}
