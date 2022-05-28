using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour {
  // Start is called before the first frame update
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }

  void OnCollisionEnter(Collision col) {
    if (col.gameObject.tag == "Tool") {
      print("Game Over! Hit by a " + col.gameObject.name);
    }
    if (col.gameObject.tag == "Lead") {
      Destroy(col.gameObject);
    }
  }
}
