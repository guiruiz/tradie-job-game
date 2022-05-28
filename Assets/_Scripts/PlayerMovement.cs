using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
  [SerializeField] Animator animator;
  public float MoveSpeed = 5f;

  private Direction CurrentDirection = Direction.CENTER;

  float MaxClamp;

  void Start() {
    SetWalkingBounds();
    RotateTo(CurrentDirection);
  }


  void Update() {
    if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)) {
      animator.SetBool("isRunning", false);
      RotateTo(Direction.CENTER);
      return;
    }

    if (Input.GetKey(KeyCode.A)) {
      animator.SetBool("isRunning", true);
      RotateTo(Direction.LEFT);
      MoveTo(Direction.LEFT);

    }
    if (Input.GetKey(KeyCode.D)) {
      animator.SetBool("isRunning", true);
      RotateTo(Direction.RIGHT);
      MoveTo(Direction.RIGHT);

    }

    if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D)) {
      animator.SetBool("isRunning", false);
      RotateTo(Direction.CENTER);
    }
  }

  void MoveTo(Direction direction) {
    if (direction == Direction.CENTER) { return; }

    Vector3 pos = transform.position;

    float x = MoveSpeed * Time.deltaTime;
    if (direction == Direction.LEFT) {
      x *= -1;
    };

    pos.x += x;
    pos.x = Mathf.Clamp(pos.x, -MaxClamp, MaxClamp);

    transform.position = pos;
  }

  int GetRotationDelta(Direction currentDirection, Direction nextDirection) {
    int rotation = currentDirection - nextDirection;
    return rotation;
  }

  void RotateTo(Direction direction) {
    int rotation = GetRotationDelta(CurrentDirection, direction);

    transform.Rotate(new Vector3(0, rotation, 0));
    CurrentDirection = direction;
  }

  void SetWalkingBounds() {
    Camera cam = Camera.main;
    float height = 2f * cam.orthographicSize;
    float width = height * cam.aspect;
    MaxClamp = width / 2;
  }
}

enum Direction {
  LEFT = -90,
  CENTER = 0,
  RIGHT = +90,
}