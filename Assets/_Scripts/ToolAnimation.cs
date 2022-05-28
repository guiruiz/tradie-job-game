using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolAnimation : MonoBehaviour {
  float degreesPerSecond = 90;
  void Update() {

    transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);
  }
}
