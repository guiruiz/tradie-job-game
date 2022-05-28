using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHit : MonoBehaviour {

  void OnCollisionEnter(Collision col) {
    if (col.gameObject.tag == "Tool" || col.gameObject.tag == "Lead") {
      Destroy(col.gameObject);
    }
  }
}
