using UnityEngine;

public class BubbleAimController : MonoBehaviour
{
    //public Transform pivot;
    public Transform shootPoint;
    public LineRenderer lineRenderer;

    public float maxDistance = 20f;
    public LayerMask collisionMask;
    public int reflections = 1;

    Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {

        RotateTowardMouse();
        DrawLine();
    }



    // ---------------- AIM ----------------
    void RotateTowardMouse()
    {
        Vector3 mouse =
            cam.ScreenToWorldPoint(Input.mousePosition);

        mouse.z = 0;

        //Vector2 dir = mouse - pivot.position;
        Vector2 dir = mouse - shootPoint.position;

        float angle =
            Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        //pivot.rotation =
        //    Quaternion.Euler(0, 0, angle - 90f);
        shootPoint.rotation =
          Quaternion.Euler(0, 0, angle - 90f);
    }

    // ---------------- PREDICTION ----------------
    void DrawLine()
    {
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, shootPoint.position);

        Vector2 direction = shootPoint.up;
        Vector2 startPos = shootPoint.position;

        int index = 1;

        for (int i = 0; i < reflections; i++)
        {
            RaycastHit2D hit =
                Physics2D.Raycast(
                    startPos,
                    direction,
                    maxDistance,
                    collisionMask);

            if (hit.collider != null)
            {
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(index, hit.point);
                index++;

                direction =
                    Vector2.Reflect(direction, hit.normal);

                startPos = hit.point;
            }
            else
            {
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(
                    index,
                    startPos + direction * maxDistance);
                break;
            }
        }
    }
}
