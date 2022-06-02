public class Tool : DropableBase {
  public override DropableType GetDropableType() => DropableType.TOOL;
  public virtual int GetDamage() {
    return 1;
  }
}

