
using UnityEngine;

public class ObjectSpawnManager : MonoBehaviour {
  public float SpawnDelay = 1;

  [SerializeField] GameObject[] ObjectPrefabs;

  private float LastSpawnTime;

  void Start() {
    LastSpawnTime = Time.time;
  }

  void Update() {
    float now = Time.time;
    // @todo Descrease SpawnDelay according to Time.time
    if (shouldSpawn(now)) {
      GameObject tool = GetRandomTool();
      SpawnTool(tool);

      LastSpawnTime = now;
    }
  }

  void SpawnTool(GameObject tool) {
    float xSpawnRange = transform.localScale.x / 2;
    float posX = Random.Range(-xSpawnRange, xSpawnRange);

    float posY = transform.position.y;

    Instantiate(tool, new Vector3(posX, posY, 0), Quaternion.identity);
  }

  protected bool shouldSpawn(float now) {
    return now - LastSpawnTime > SpawnDelay;
  }

  GameObject GetRandomTool() {
    int randomToolIndex = Random.Range(0, ObjectPrefabs.Length - 1);
    return ObjectPrefabs[randomToolIndex];
  }
}
