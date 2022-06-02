using System;
using UnityEngine;

public class PlayerCollider : StaticInstance<PlayerCollider> {

  void OnCollisionEnter(Collision col) {
    GameObject colGameObject = col.gameObject;
    DropableBase dropable = colGameObject.GetComponent<DropableBase>();

    if (dropable?.GetDropableType() == DropableType.TOOL) {
      EventsManager.Instance.ToolHit((Tool)dropable);
      Destroy(colGameObject);
    }

    if (dropable?.GetDropableType() == DropableType.LEAD) {
      EventsManager.Instance.LeadClaimed();
      Destroy(colGameObject);
    }

  }
}
