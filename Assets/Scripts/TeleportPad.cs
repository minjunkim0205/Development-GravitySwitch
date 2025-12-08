using UnityEngine;

public class TeleportPad : MonoBehaviour, IUsablePad
{
    public TeleportPad targetPad;      // 연결된 반대쪽 텔레포트 패드
    public Transform teleportPoint;    // 도착 위치

    private bool isCooldown = false;
    public float cooldownTime = 0.3f;

    public void OnUse(PC_Game player)
    {
        if (isCooldown) return;
        if (targetPad == null || teleportPoint == null) return;

        Rigidbody rb = player.GetComponentInChildren<Rigidbody>();

        // 텔레포트 이동
        rb.position = targetPad.teleportPoint.position;
        rb.linearVelocity = Vector3.zero;

        // 양쪽 쿨다운 설정
        StartCooldown();
        targetPad.StartCooldown();
    }

    private void StartCooldown()
    {
        isCooldown = true;
        Invoke(nameof(ResetCooldown), cooldownTime);
    }

    private void ResetCooldown()
    {
        isCooldown = false;
    }
}
