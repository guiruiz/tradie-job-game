using UnityEngine;

public class Hammer : Tool {

  protected override Vector3 RotationAxis() => new Vector3(0, 0, RotationPerSecond());
}

