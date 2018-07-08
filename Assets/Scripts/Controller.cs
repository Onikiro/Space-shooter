using SciptableObjects;
using System;
using UnityEngine;

/// <inheritdoc />
/// <summary>
/// Player controller 
/// </summary>
public class Controller : MonoBehaviour
{

    public static event Action OnGameOver;
    private float _nextFire;
    private Rigidbody2D _rbody2D;
    private float _speed, _fireRate;
    private const float SelfSizeX = 1.5f;
    private const float SelfSizeY = 0.75f;
    private Transform _shotPointer;
    private ObjectPool _bullets;
    private CameraBorders _borders;
    [SerializeField] private PlayerSettings _settings;

    private void Start()
    {
        _rbody2D = GetComponent<Rigidbody2D>();
        _bullets = GetComponent<ObjectPool>();
        _borders = Camera.main.GetComponent<CameraBorders>();
        _shotPointer = GameObject.Find("shotPoint").transform;

        _speed = _settings.ShipMovementSpeed;
        _fireRate = _settings.FireRate;
    }

    private void Update()
    {
        Fire();
    }

    private void FixedUpdate()
    {
        Move();

        _rbody2D.position = new Vector2
            (
            Mathf.Clamp(_rbody2D.position.x, _borders.MinX + SelfSizeX, _borders.MaxX - SelfSizeX),
            Mathf.Clamp(_rbody2D.position.y, _borders.MinY + SelfSizeY, _borders.MaxY - SelfSizeY)
            );
    }

    private void Move()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector2(moveHorizontal, moveVertical);

        _rbody2D.velocity = (movement * _speed);
    }

    private void Fire()
    {
        if (Input.GetButton("Fire") && Time.time > _nextFire)
        {
            if (_fireRate < 0.01f) return;
            _nextFire = Time.time + 1 / _fireRate;
            var bullet = _bullets.GetObject();
            bullet.transform.position = _shotPointer.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("stone"))
        {
            if (OnGameOver != null) OnGameOver();
        }
    }
}
