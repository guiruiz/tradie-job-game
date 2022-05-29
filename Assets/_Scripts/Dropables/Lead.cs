public class Lead : DropableBase {
  protected override float RotationPerSecond() => 120f;
  public override DropableType GetDropableType() => DropableType.LEAD;
}
