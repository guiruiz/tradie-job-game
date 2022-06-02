using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {
  [SerializeField] int CameraShakeFrames = 100;
  [SerializeField] float Intensity = .1f;
  [SerializeField] float Frequency = 1f;


  private void Start() {
    PlayerCollider.Instance.OnToolHit += ShakeCamera;
  }

  void ShakeCamera(Tool _) {
    StopAllCoroutines();
    StartCoroutine(CameraShakeCoroutine());
  }

  IEnumerator CameraShakeCoroutine() {
    var originalposition = transform.position;

    for (int i = 0; i < CameraShakeFrames; i++) {
      transform.position = originalposition + (Vector3.right * Intensity * Mathf.Cos(i * Frequency) * (100 - i) / CameraShakeFrames);
      yield return null;
    }

    transform.position = originalposition;
  }
}

