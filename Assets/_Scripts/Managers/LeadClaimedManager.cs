
using System;
using TMPro;
using UnityEngine;

public class LeadClaimedManager : StaticInstance<HealthManager> {

  [SerializeField] TextMeshProUGUI ClaimCounter;

  private int LeadClaimedCount;

  void Start() {
    GameManager.Instance.OnGameStart += Initialize;
    PlayerCollider.Instance.OnLeadClaimed += LeadClaimed;
  }

  void Initialize() {
    LeadClaimedCount = 0;
    SetClaimCounter(LeadClaimedCount);
  }

  void SetClaimCounter(int claim) {
    ClaimCounter.text = claim.ToString();
  }

  void LeadClaimed() {
    LeadClaimedCount++;
    SetClaimCounter(LeadClaimedCount);
  }

}
