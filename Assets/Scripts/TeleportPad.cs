using UnityEngine;

public class TeleportPad : MonoBehaviour, IUsablePad
{
    public TeleportPad targetPad;
    public Transform teleportPoint;

    private bool isCooldown = false;
    public float cooldownTime = 0.3f;

    public void OnUse(PC_Game player)
    {
        if (isCooldown) return;
        if (targetPad == null || teleportPoint == null) return;

        Rigidbody rb = player.GetComponentInChildren<Rigidbody>();

        rb.position = targetPad.teleportPoint.position;
        rb.linearVelocity = Vector3.zero;

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
