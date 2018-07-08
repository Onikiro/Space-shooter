using UnityEngine;

/// <inheritdoc />
/// <summary>
/// Configure borders for stones and bullets 
/// </summary>
public class CameraBorders : MonoBehaviour {

    public float MinX { get; private set; }
    public float MaxX { get; private set; }
    public float MinY { get; private set; }
    public float MaxY { get; private set; }

    [SerializeField]
    private GameObject _bulletBorder;
    [SerializeField]
    private GameObject _stoneBorderX;
    [SerializeField]
    private GameObject _stoneBorderTopY;
    [SerializeField]
    private GameObject _stoneBorderBotY;
    [SerializeField]
    private float _offset;

    private void Start () {
        var cam = Camera.main;

        var camDistance = Vector2.Distance(transform.position, cam.transform.position);
        Vector2 bottomCorner = cam.ViewportToWorldPoint(new Vector3(0, 0, camDistance));
        Vector2 topCorner = cam.ViewportToWorldPoint(new Vector3(1, 1, camDistance));

        MinX = bottomCorner.x;
        MaxX = topCorner.x;
        MinY = bottomCorner.y;
        MaxY = topCorner.y;

        _bulletBorder.transform.position = new Vector2(MaxX + _bulletBorder.GetComponent<Collider2D>().bounds.size.x + _offset, 0);
        _stoneBorderX.transform.position = new Vector2(MinX - _stoneBorderX.GetComponent<Collider2D>().bounds.size.x - _offset, 0);
        _stoneBorderTopY.transform.position = new Vector2(0, MaxY + _stoneBorderTopY.GetComponent<Collider2D>().bounds.size.y + _offset);
        _stoneBorderBotY.transform.position = new Vector2(0, MinY - _stoneBorderBotY.GetComponent<Collider2D>().bounds.size.y - _offset);
    }
}
