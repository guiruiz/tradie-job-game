using UnityEngine;
public class GameUIDisplay : MonoBehaviour {
  [SerializeField] GameObject GameStartUI;
  [SerializeField] GameObject GameOverUI;

  void Awake() {
    GameManager.OnGameStart += OnGameStart;
    GameManager.OnGameOver += OnGameOver;
  }

  void Start() {
    GameStartUI.SetActive(true);
    GameOverUI.SetActive(false);
  }

  void OnDestroy() {
    GameManager.OnGameStart -= OnGameStart;
    GameManager.OnGameOver -= OnGameOver;
  }

  void OnGameStart() {
    GameStartUI.SetActive(false);
    GameOverUI.SetActive(false);
  }

  void OnGameOver() {
    GameStartUI.SetActive(false);
    GameOverUI.SetActive(true);
  }
}
