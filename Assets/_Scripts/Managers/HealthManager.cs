
using System;
using UnityEngine;

public class HealthManager : StaticInstance<HealthManager> {

  [SerializeField] GameObject[] HealthIcons;

  private int CurrentHealth;

  void Start() {
    GameManager.Instance.OnGameStart += Initialize;
    PlayerCollider.Instance.OnToolHit += TakeDamage;
  }

  void Initialize() {
    setHealth(HealthIcons.Length);
  }

  void setHealth(int health) {
    if (health < 0) { return; }

    GameObject[] activeIcons = HealthIcons[..health];
    GameObject[] deactiveIcons = HealthIcons[health..];

    setIconActives(activeIcons, true);
    setIconActives(deactiveIcons, false);


    CurrentHealth = health;
  }

  void setIconActives(GameObject[] icons, bool active) {
    foreach (var icon in icons) {
      icon.SetActive(active);
    }
  }

  void TakeDamage(Tool tool) {
    setHealth(CurrentHealth - 1);

    if (CurrentHealth <= 0) {
      Die();
    }
  }

  void Die() {
    GameManager.Instance.GameOver();
  }
}
