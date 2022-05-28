using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {

  void Start() {

  }

  void Update() {

  }

  void OnCollisionEnter(Collision col) {
    GameObject dropable = col.gameObject;
    if (dropable.GetComponent<Tool>()) {

      print("Game Over! Hit by a " + dropable.name);
    }
    if (dropable.GetComponent<Lead>()) {
      Destroy(dropable);
    }
  }
}
