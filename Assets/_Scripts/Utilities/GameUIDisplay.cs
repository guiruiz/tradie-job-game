using UnityEngine;
public class GameUIDisplay : MonoBehaviour {
  [SerializeField] GameObject GameStartUI;
  [SerializeField] GameObject GameOverUI;

  void Start() {
    EventsManager.Instance.OnGameStart += OnGameStart;
    EventsManager.Instance.OnGameOver += OnGameOver;

    GameStartUI.SetActive(true);
    GameOverUI.SetActive(false);
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
