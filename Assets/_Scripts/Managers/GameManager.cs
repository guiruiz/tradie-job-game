using System;
using UnityEngine;

public class GameManager : StaticInstance<GameManager> {
  private bool isPlaying = false;

  void Update() {
    if (Input.GetKeyDown(KeyCode.Space) && !isPlaying) {
      StartGame();
    }
  }

  public void StartGame() {
    isPlaying = true;
    EventsManager.Instance.StartGame();
  }

  public void GameOver() {
    isPlaying = false;
    EventsManager.Instance.GameOver();
  }
}