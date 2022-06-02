using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerDirection {
  LEFT = -90,
  CENTER = 0,
  RIGHT = +90,
}

public enum PlayerMoveMode {
  WALK = 5,
  RUN = 10,
}

public class PlayerMovement : MonoBehaviour {
  [SerializeField] Animator animator;
  private float WalkingBounds;
  private PlayerDirection CurrentDirection = PlayerDirection.CENTER;
  private PlayerMoveMode CurrentMoveMode;
  private bool CanMove = false;

  void Start() {
    GameManager.Instance.OnGameStart += AllowMove;
    GameManager.Instance.OnGameOver += DisallowMove;
    PlayerInput.Instance.OnPlayerMove += Move;
    PlayerInput.Instance.OnPlayerMove += RotateTo;
    PlayerInput.Instance.OnPlayerStop += Stop;
    PlayerInput.Instance.OnSetPlayerMoveMode += SetPlayerMoveMode;

    SetWalkingBounds();
    RotateTo(CurrentDirection);
    SetPlayerMoveMode(PlayerMoveMode.WALK);
  }

  void AllowMove() {
    CanMove = true;
  }

  void DisallowMove() {
    RotateTo(PlayerDirection.CENTER);
    CanMove = false;
  }

  void Stop() {
    animator.SetBool("isRunning", false);
    RotateTo(PlayerDirection.CENTER);
  }

  void Move(PlayerDirection direction) {
    if (!CanMove || direction == PlayerDirection.CENTER) {
      return;
    }
    animator.SetBool("isRunning", true);

    Vector3 pos = transform.position;

    int playerSpeed = (int)CurrentMoveMode;
    float x = playerSpeed * Time.deltaTime;
    if (direction == PlayerDirection.LEFT) {
      x *= -1;
    };

    pos.x += x;
    pos.x = Mathf.Clamp(pos.x, -WalkingBounds, WalkingBounds);

    transform.position = pos;
  }

  int GetRotationDelta(PlayerDirection currentDirection, PlayerDirection nextDirection) {
    int rotation = currentDirection - nextDirection;
    return rotation;
  }

  void RotateTo(PlayerDirection direction) {
    if (!CanMove) {
      return;
    }

    int rotation = GetRotationDelta(CurrentDirection, direction);

    transform.Rotate(new Vector3(0, rotation, 0));
    CurrentDirection = direction;
  }

  void SetPlayerMoveMode(PlayerMoveMode moveMode) {
    CurrentMoveMode = moveMode;
  }

  void SetWalkingBounds() {
    Camera cam = Camera.main;
    float height = 2f * cam.orthographicSize;
    float width = height * cam.aspect;
    WalkingBounds = width / 2;
  }
}
