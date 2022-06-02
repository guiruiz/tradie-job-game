using System;
using UnityEngine;

public class PlayerInput : StaticInstance<PlayerInput> {


  void Update() {
    if ((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) {
      EventsManager.Instance.StopPlayer();
      return;
    }

    if (Input.GetKey(KeyCode.A)) {
      EventsManager.Instance.MovePlayer(PlayerDirection.LEFT);
    }

    if (Input.GetKey(KeyCode.D)) {
      EventsManager.Instance.MovePlayer(PlayerDirection.RIGHT);
    }

    if (Input.GetKey(KeyCode.LeftShift)) {
      EventsManager.Instance.SetPlayerMoveMode(PlayerMoveMode.RUN);
    } else {
      EventsManager.Instance.SetPlayerMoveMode(PlayerMoveMode.WALK);
    }

  }
}
