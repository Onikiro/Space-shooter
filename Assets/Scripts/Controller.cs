using System;
using UnityEngine;

public class Controller : MonoBehaviour {

    public static event Action OnGameOver;
    private float nextFire;
    private Rigidbody2D rbody2d;
    private float speed, fireRate;
    private float selfSizeX = 1.5f, selfSizeY = 0.75f;
    Transform shotPointer;
    private ObjectPool bullets;
    CameraBorders borders;
    [SerializeField]
    PlayerSettings settings;

    void Start()
    {
        rbody2d = GetComponent<Rigidbody2D>();
        bullets = GetComponent<ObjectPool>();
        borders = Camera.main.GetComponent<CameraBorders>();
        shotPointer = GameObject.Find("shotPoint").transform;

        speed = settings.ShipMovementSpeed;
        fireRate = settings.FireRate;
    }

    void Update()
    {
        Fire();
    }

    void FixedUpdate()
    {
        Move();

        rbody2d.position = new Vector2
            (
            Mathf.Clamp(rbody2d.position.x, borders.MinX + selfSizeX, borders.MaxX - selfSizeX),
            Mathf.Clamp(rbody2d.position.y, borders.MinY + selfSizeY, borders.MaxY - selfSizeY)
            );
    }

    void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rbody2d.velocity = (movement * speed);
    }

    void Fire()
    {
        if (Input.GetButton("Fire") && Time.time > nextFire)
        {
            if (fireRate == 0) return;
            nextFire = Time.time + 1 / fireRate;
            var bullet = bullets.GetObject();
            bullet.transform.position = shotPointer.position;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("stone"))
        {
            OnGameOver();
        }
    }
}
