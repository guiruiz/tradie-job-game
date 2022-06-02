using System;
using UnityEngine;

public class GameManager : StaticInstance<GameManager> {
  public event Action OnGameStart;
  public event Action OnGameOver;
  private bool isPlaying = false;

  void Update() {
    if (Input.GetKeyDown(KeyCode.Space) && !isPlaying) {
      StartGame();
    }
  }

  public void StartGame() {
    isPlaying = true;
    OnGameStart?.Invoke();
  }

  public void GameOver() {
    isPlaying = false;
    OnGameOver?.Invoke();
  }
}