using System;


public class EventsManager : StaticInstance<EventsManager> {
  // Game Events
  public event Action OnGameStart;
  public event Action OnGameOver;
  public void StartGame() {
    OnGameStart?.Invoke();
  }
  public void GameOver() {
    OnGameOver?.Invoke();
  }

  // Player Events
  public event Action<PlayerDirection> OnPlayerMove;
  public event Action OnPlayerStop;
  public event Action<PlayerMoveMode> OnSetPlayerMoveMode;
  public void MovePlayer(PlayerDirection direction) {
    OnPlayerMove?.Invoke(direction);
  }
  public void StopPlayer() {
    OnPlayerStop?.Invoke();
  }
  public void SetPlayerMoveMode(PlayerMoveMode moveMode) {
    OnSetPlayerMoveMode?.Invoke(moveMode);
  }

  // Dropable Events
  public event Action<Tool> OnToolHit;
  public event Action OnLeadClaimed;

  public void ToolHit(Tool tool) {
    OnToolHit?.Invoke(tool);
  }
  public void LeadClaimed() {
    OnLeadClaimed?.Invoke();
  }
}
