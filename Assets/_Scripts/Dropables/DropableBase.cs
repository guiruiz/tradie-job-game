using UnityEngine;

public abstract class DropableBase : MonoBehaviour {

  void Update() {
    Rotate();
  }

  public virtual DropableType GetDropableType() {
    throw new System.Exception("Method GetDropableType not implemented");
  }

  protected virtual float RotationSpeed() => 90f;

  protected virtual Vector3 RotationAxis() => new Vector3(0, RotationSpeed(), 0);

  protected void Rotate() {
    transform.Rotate(RotationAxis() * Time.deltaTime);
  }
}

public enum DropableType {
  TOOL = 'T',
  LEAD = 'L',
}
