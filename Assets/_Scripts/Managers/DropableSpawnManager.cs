
using System.Collections;
using UnityEngine;

public class DropableSpawnManager : MonoBehaviour {
  public float SpawnDelay = 1f;
  [SerializeField] DropableBase[] DropablePrefabs;
  private Coroutine SpawnRoutine;

  void Start() {
    EventsManager.Instance.OnGameStart += StartSpawning;
    EventsManager.Instance.OnGameOver += StopSpawning;
  }
  private void StartSpawning() {
    SpawnRoutine = StartCoroutine(SpawnDropables());
  }

  private void StopSpawning() {
    if (SpawnRoutine != null) {
      StopCoroutine(SpawnRoutine);
    }
  }

  IEnumerator SpawnDropables() {
    while (true) {
      float xSpawnRange = transform.localScale.x / 2;
      float posX = Random.Range(-xSpawnRange, xSpawnRange);
      float posY = transform.position.y;

      DropableBase dropable = GetRandomDropable();
      Instantiate(dropable, new Vector3(posX, posY, 0), Quaternion.identity);

      yield return new WaitForSeconds(SpawnDelay);
    }
  }

  DropableBase GetRandomDropable() {
    int randomToolIndex = Random.Range(0, DropablePrefabs.Length - 1);
    return DropablePrefabs[randomToolIndex];
  }
}
