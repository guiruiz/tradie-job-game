using UnityEngine;

public abstract class DropableBase : MonoBehaviour {

  void Update() {
    Rotate();
  }

  protected virtual float RotationPerSecond() => 90f;
  protected virtual Vector3 RotationAxis() => new Vector3(0, RotationPerSecond(), 0);
  protected void Rotate() {
    transform.Rotate(RotationAxis() * Time.deltaTime);
  }

  public abstract DropableType GetDropableType();
}

public enum DropableType {
  TOOL = 'T',
  LEAD = 'L',
}
