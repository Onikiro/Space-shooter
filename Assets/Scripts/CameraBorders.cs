using UnityEngine;

public class CameraBorders : MonoBehaviour {

    public float MinX { get; private set; }
    public float MaxX { get; private set; }
    public float MinY { get; private set; }
    public float MaxY { get; private set; }

    [SerializeField]
    private GameObject bulletBorder;
    [SerializeField]
    private GameObject stoneBorderX;
    [SerializeField]
    private GameObject stoneBordertopY;
    [SerializeField]
    private GameObject stoneBorderbotY;
    [SerializeField]
    private float offset;

    void Start () {
        var camera = Camera.main;

        float camDistance = Vector2.Distance(transform.position, camera.transform.position);
        Vector2 bottomCorner = camera.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = camera.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        MinX = bottomCorner.x;
        MaxX = topCorner.x;
        MinY = bottomCorner.y;
        MaxY = topCorner.y;

        bulletBorder.transform.position = new Vector2(MaxX + bulletBorder.GetComponent<Collider2D>().bounds.size.x + offset, 0);
        stoneBorderX.transform.position = new Vector2(MinX - stoneBorderX.GetComponent<Collider2D>().bounds.size.x - offset, 0);
        stoneBordertopY.transform.position = new Vector2(0, MaxY + stoneBordertopY.GetComponent<Collider2D>().bounds.size.y + offset);
        stoneBorderbotY.transform.position = new Vector2(0, MinY - stoneBorderbotY.GetComponent<Collider2D>().bounds.size.y - offset);
    }
}
