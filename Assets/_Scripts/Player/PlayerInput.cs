using System;
using UnityEngine;

public class PlayerInput : StaticInstance<PlayerInput> {
  public event Action<PlayerDirection> OnPlayerMove;
  public event Action OnPlayerStop;
  public event Action<PlayerMoveMode> OnSetPlayerMoveMode;

  void Update() {
    if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) {
      OnPlayerStop?.Invoke();
      return;
    }

    if (Input.GetKey(KeyCode.A)) {
      OnPlayerMove?.Invoke(PlayerDirection.LEFT);
    }

    if (Input.GetKey(KeyCode.D)) {
      OnPlayerMove?.Invoke(PlayerDirection.RIGHT);
    }

    if (Input.GetKey(KeyCode.LeftShift)) {
      OnSetPlayerMoveMode?.Invoke(PlayerMoveMode.RUN);
    } else {
      OnSetPlayerMoveMode?.Invoke(PlayerMoveMode.WALK);
    }

  }
}
