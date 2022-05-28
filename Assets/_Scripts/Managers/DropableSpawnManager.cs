
using UnityEngine;

public class DropableSpawnManager : MonoBehaviour {
  public float SpawnDelay = 1;

  [SerializeField] DropableBase[] DropablePrefabs;

  private float LastSpawnTime;

  void Start() {
    LastSpawnTime = Time.time;
  }

  void Update() {
    float now = Time.time;
    // @todo Descrease SpawnDelay according to Time.time
    if (shouldSpawn(now)) {
      DropableBase tool = GetRandomTool();
      SpawnTool(tool);

      LastSpawnTime = now;
    }
  }

  void SpawnTool(DropableBase tool) {
    float xSpawnRange = transform.localScale.x / 2;
    float posX = Random.Range(-xSpawnRange, xSpawnRange);

    float posY = transform.position.y;

    Instantiate(tool, new Vector3(posX, posY, 0), Quaternion.identity);
  }

  protected bool shouldSpawn(float now) {
    return now - LastSpawnTime > SpawnDelay;
  }

  DropableBase GetRandomTool() {
    int randomToolIndex = Random.Range(0, DropablePrefabs.Length - 1);
    return DropablePrefabs[randomToolIndex];
  }
}
