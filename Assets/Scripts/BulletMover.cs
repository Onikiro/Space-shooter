using UnityEngine;

public class BulletMover : MonoBehaviour {

    [SerializeField]
    private float speed;
    private ObjectPool pool;
    private GameProcessHandler gameProcess;
    private int points;
    [SerializeField]
    private GeneralSettings settings;


    void Awake()
    {
        pool = GameObject.Find("Ship").GetComponent<ObjectPool>();
        gameProcess = GameObject.Find("GameProcess").GetComponent<GameProcessHandler>();

        points = settings.PointsPerStone;
    }

    void OnEnable()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("stone"))
        {
            gameProcess.Score += points;
            pool.PutObject(gameObject);
        }
        else if (other.IsTouchingLayers())
        {
            pool.PutObject(gameObject);
        }
    }
}
