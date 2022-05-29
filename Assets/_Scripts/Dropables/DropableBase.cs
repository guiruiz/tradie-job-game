using UnityEngine;

public abstract class DropableBase : MonoBehaviour {

  void Update() {
    Rotate();
  }

  protected virtual float RotationPerSecond() => 90f;

  private void Rotate() {
    transform.Rotate(new Vector3(0, RotationPerSecond(), 0) * Time.deltaTime);
  }
  public abstract DropableType GetDropableType();
}

public enum DropableType {
  TOOL = 'T',
  LEAD = 'L',
}
