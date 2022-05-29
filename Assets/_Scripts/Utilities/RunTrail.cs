using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunTrail : MonoBehaviour {
  [SerializeField] TrailRenderer renderer;
  void Update() {
    if (Input.GetKey(KeyCode.LeftShift)) {
      renderer.emitting = true;
    } else {
      renderer.emitting = false;
    }
  }
}
