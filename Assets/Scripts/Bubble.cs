using UnityEngine;

public class Bubble : MonoBehaviour
{
    public BubbleData data;
    private SpriteRenderer sr;
    private Rigidbody2D rb;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    public void Setup(BubbleData bubbleData)
    {
        data = bubbleData;
        sr.color = data.color;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }


    public void ResetBubble()
    {
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

}
