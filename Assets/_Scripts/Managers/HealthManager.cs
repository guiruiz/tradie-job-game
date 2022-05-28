
using System;
using UnityEngine;

public class HealthManager : MonoBehaviour {

  [SerializeField] GameObject[] HealthIcons;

  private int CurrentHealth;

  void Start() {
    setHealth(HealthIcons.Length);
  }

  void setHealth(int health) {
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

  void TakeDamage(int damage) {

  }
}
