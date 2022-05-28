using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolSpawnManager : MonoBehaviour {
  private float SpawnDelay = .5f;

  [SerializeField] GameObject[] ToolPrefabs;
  private float LastSpawnTime;

  void Start() {
    LastSpawnTime = Time.time;
  }

  void Update() {
    float now = Time.time;
    // @todo Descrease SpawnDelay according to Time.time
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
    int randomToolIndex = Random.Range(0, ToolPrefabs.Length - 1);
    return ToolPrefabs[randomToolIndex];
  }
}
