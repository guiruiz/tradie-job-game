
using System;
using TMPro;
using UnityEngine;

public class LeadClaimedManager : StaticInstance<HealthManager> {

  [SerializeField] TextMeshProUGUI ClaimCounter;

  private int LeadClaimedCount;

  protected override void Awake() {
    base.Awake();
    GameManager.OnGameStart += Initialize;
    PlayerCollider.OnLeadClaimed += LeadClaimed;
  }

  void Initialize() {
    LeadClaimedCount = 0;
    SetClaimCounter(LeadClaimedCount);
  }

  private void OnDestroy() {
    GameManager.OnGameStart -= Initialize;
    PlayerCollider.OnLeadClaimed -= LeadClaimed;
  }

  void SetClaimCounter(int claim) {
    ClaimCounter.text = claim.ToString();
  }

  void LeadClaimed() {
    LeadClaimedCount++;
    SetClaimCounter(LeadClaimedCount);
  }

}
