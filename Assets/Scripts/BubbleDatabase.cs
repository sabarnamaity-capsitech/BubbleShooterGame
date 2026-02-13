using UnityEngine;
using System.Collections.Generic;


[System.Serializable]
public class BubbleData
{
    public string bubbleName;
    public Color color;
}
[CreateAssetMenu(fileName = "BubbleDatabase", menuName = "Bubble/Database")]
public class BubbleDatabase :ScriptableObject
{
    public List<BubbleData> bubbles;

    public BubbleData GetRandomBubble()
    {
        return bubbles[Random.Range(0, bubbles.Count)];
    }
}
