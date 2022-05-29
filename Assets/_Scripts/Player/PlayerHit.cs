using UnityEngine;

public class PlayerHit : MonoBehaviour {

  void OnCollisionEnter(Collision col) {
    GameObject colGameObject = col.gameObject;
    DropableBase dropable = colGameObject.GetComponent<DropableBase>();

    if (dropable.GetDropableType() == DropableType.TOOL) {

      print("Game Over! Hit by a " + colGameObject.name);
    }

    if (dropable.GetDropableType() == DropableType.LEAD) {
      print("Lead claimed!");
      Destroy(colGameObject);
    }
  }
}
