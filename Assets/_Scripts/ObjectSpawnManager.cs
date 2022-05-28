using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnManager : MonoBehaviour {
  private float SpawnDelay = 2f;

  [SerializeField] GameObject[] ToolPrefabs;
  private float LastSpawnTime;

  void Start() {
    LastSpawnTime = Time.time;
  }

  void Update() {
    float now = Time.time;
    if (now - LastSpawnTime > SpawnDelay) {
      GameObject tool = GetRandomTool();
      SpawnTool(tool);

      LastSpawnTime = now;
    }
  }

  void SpawnTool(GameObject tool) {
    float xSpawnRange = transform.localScale.x / 2;
    float posX = Random.Range(-xSpawnRange, xSpawnRange);

    float posY = transform.transform.position.y;
    Instantiate(tool, new Vector3(posX, posY, 0), Quaternion.identity);
  }

  GameObject GetRandomTool() {
    return ToolPrefabs[Random.Range(0, ToolPrefabs.Length - 1)];
  }
}
