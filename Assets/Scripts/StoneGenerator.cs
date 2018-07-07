using UnityEngine;

public class StoneGenerator : MonoBehaviour {

    private float spawnRate;
    private float nextSpawn;
    private ObjectPool stones;
    CameraBorders cameraBorders;
    private float stoneSize;
    [SerializeField]
    private GeneralSettings settings;

    void Start()
    {
        stones = GetComponent<ObjectPool>();
        cameraBorders = Camera.main.GetComponent<CameraBorders>();
        stoneSize = transform.lossyScale.x;

        spawnRate = settings.StoneSpawnRate;
    }

    void Update()
    {
        SpawnStone();
    }

    void SpawnStone()
    {
        if (Time.time > nextSpawn)
        {
            if (spawnRate == 0) return;
            nextSpawn = Time.time + 1 / spawnRate;
            var stone = stones.GetObject();
            stone.transform.position = new Vector2(cameraBorders.MaxX + stoneSize, Random.Range(cameraBorders.MinY, cameraBorders.MaxY));
        }
    }
}
