using System.Collections;
using UnityEngine;

public class StoneGenerator : MonoBehaviour {

    private float spawnRate;
    private ObjectPool stones;
    CameraBorders cameraBorders;
    private float stoneSize;
    [SerializeField]
    private GeneralSettings settings;

    private void Start()
    {
        stones = GetComponent<ObjectPool>();
        cameraBorders = Camera.main.GetComponent<CameraBorders>();
        stoneSize = transform.lossyScale.x;

        spawnRate = settings.StoneSpawnRate;

        StartCoroutine(GenerateStones());
    }

    private IEnumerator GenerateStones()
    {
        yield return null;
        if (spawnRate < 0.01f) yield break;
        SpawnStone();
        var nextSpawn = Time.time + 1 / spawnRate;
        yield return new WaitUntil(() => Time.time > nextSpawn);
        yield return GenerateStones();
    }

    private void SpawnStone()
    {
        var stone = stones.GetObject();
        stone.transform.position = new Vector2(cameraBorders.MaxX + stoneSize, Random.Range(cameraBorders.MinY, cameraBorders.MaxY));
    }
}
