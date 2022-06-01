
using System;
using TMPro;
using UnityEngine;

public class LeadClaimedManager : StaticInstance<HealthManager> {

  [SerializeField] TextMeshProUGUI ClaimCounter;

  private int LeadClaimedCount = 0;

  protected override void Awake() {
    base.Awake();
    PlayerCollider.OnLeadClaimed += LeadClaimed;
  }

  void Start() {
    SetClaimCounter(LeadClaimedCount);
  }

  private void OnDestroy() {
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
