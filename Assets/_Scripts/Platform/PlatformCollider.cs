using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollider : MonoBehaviour {

  void OnCollisionEnter(Collision col) {
    GameObject colGameObject = col.gameObject;
    DropableBase dropable = colGameObject.GetComponent<DropableBase>();

    if (dropable?.GetDropableType() == DropableType.TOOL || dropable?.GetDropableType() == DropableType.LEAD) {
      Destroy(colGameObject);
    }
  }
}
