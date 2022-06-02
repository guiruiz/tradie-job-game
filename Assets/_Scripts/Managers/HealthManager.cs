
using System;
using UnityEngine;

public class HealthManager : StaticInstance<HealthManager> {

  [SerializeField] GameObject[] HealthIcons;

  private int MaxHealth;
  private int CurrentHealth;

  void Start() {
    GameManager.Instance.OnGameStart += Initialize;
    PlayerCollider.Instance.OnToolHit += TakeDamage;
  }

  void Initialize() {
    MaxHealth = HealthIcons.Length;
    setHealth(MaxHealth);
  }

  void setHealth(int health) {
    health = Mathf.Clamp(health, 0, MaxHealth);

    GameObject[] activeIcons = HealthIcons[..health];
    GameObject[] deactiveIcons = HealthIcons[health..];

    changeIconVisibility(activeIcons, true);
    changeIconVisibility(deactiveIcons, false);


    CurrentHealth = health;
  }

  void changeIconVisibility(GameObject[] icons, bool visible) {
    foreach (var icon in icons) {
      icon.SetActive(visible);
    }
  }

  void TakeDamage(Tool tool) {
    setHealth(CurrentHealth - tool.GetDamage());

    if (CurrentHealth <= 0) {
      Die();
    }
  }

  void Die() {
    GameManager.Instance.GameOver();
  }
}
