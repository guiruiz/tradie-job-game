using System;
using UnityEngine;

public class GameManager : StaticInstance<GameManager> {
  public static event Action<GameState> OnBeforeStateChanged;
  public static event Action<GameState> OnAfterStateChanged;

  public GameState State { get; private set; }


  void Start() {
    ChangeState(GameState.Menu);
  }

  public void ChangeState(GameState newState) {
    OnBeforeStateChanged?.Invoke(newState);

    State = newState;
    switch (newState) {
      case GameState.Menu:
        HandlePlaying();
        break;
      case GameState.Playing:
        HandlePlaying();
        break;
      case GameState.GameOver:
        HandleGameOver();
        break;
      default:
        throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
    }

    OnAfterStateChanged?.Invoke(newState);
  }


  private void HandleMenu() {
    // show menu
  }
  private void HandlePlaying() {
    // spawn enemies menu
  }

  private void HandleGameOver() {
    // show game over screen
  }

}

[Serializable]
public enum GameState {
  Menu = 0,
  Playing = 1,
  GameOver = 2,
}