using System;
using UnityEngine;

public class PlayerCollider : MonoBehaviour {

  // @ should this class be static?
  // @ todo review static actions
  public static event Action<Tool> OnToolHit;
  public static event Action OnLeadClaimed;

  void OnCollisionEnter(Collision col) {
    GameObject colGameObject = col.gameObject;
    DropableBase dropable = colGameObject.GetComponent<DropableBase>();

    if (dropable?.GetDropableType() == DropableType.TOOL) {
      OnToolHit?.Invoke((Tool)dropable);
      Destroy(colGameObject);
    }

    if (dropable?.GetDropableType() == DropableType.LEAD) {
      OnLeadClaimed?.Invoke();
      Destroy(colGameObject);
    }

  }
}
