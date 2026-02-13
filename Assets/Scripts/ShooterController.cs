using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public static ShooterController Instance;

    public Transform shootPoint;      // where bubble stays
    public BubbleDatabase database;   // bubble colors

    private Bubble currentBubble;

    private void Awake()
    {
        Instance = this;
    }

    // Called when game starts
    public void LoadBubble()
    {
        Debug.Log("LoadBubble called");

        if (BubblePool.Instance == null)
            Debug.LogError("BubblePool Instance NULL");

        if (database == null)
            Debug.LogError("Database NOT assigned");

        if (shootPoint == null)
            Debug.LogError("ShootPoint NOT assigned");

        Bubble b = BubblePool.Instance.GetBubble();

        if (b == null)
        {
            Debug.LogError("Pool returned NULL bubble");
            return;
        }

        BubbleData data = database.GetRandomBubble();
        b.Setup(data);

        b.transform.SetParent(shootPoint);
        b.transform.localPosition = Vector3.zero;

        currentBubble = b;
    }


}
