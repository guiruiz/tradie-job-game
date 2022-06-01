using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTrail : MonoBehaviour {
  [SerializeField] TrailRenderer TrailRenderer;
  void Update() {
    if (Input.GetKey(KeyCode.LeftShift)) {
      TrailRenderer.emitting = true;
    } else {
      TrailRenderer.emitting = false;
    }
  }
}
