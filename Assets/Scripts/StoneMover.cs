using UnityEngine;

public class StoneMover : MonoBehaviour {

    private float speed, angle;
    private ObjectPool pool;
    [SerializeField]
    private GeneralSettings settings;

    void Awake()
    {
        pool = GameObject.Find("StoneManager").GetComponent<ObjectPool>();

        speed = settings.StoneMovementSpeed;
        angle = settings.StoneSpreadAngle;
    }

    void OnEnable()
    {
        GetComponent<Rigidbody2D>().velocity = -Vector2FromAngle(Random.Range(-angle, angle)) * speed; 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet") || other.IsTouchingLayers())
        {
            pool.PutObject(gameObject);
        }
    }

    public Vector2 Vector2FromAngle(float a)
    {
        a *= Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
    }
}
