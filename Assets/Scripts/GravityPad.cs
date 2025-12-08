using UnityEngine;

public class GravityPad : MonoBehaviour, IUsablePad
{
    public float boostForce = 10f;

    public void OnUse(PC_Game player)
    {
        player.gravityDir = -player.gravityDir;

        Rigidbody rb = player.GetComponentInChildren<Rigidbody>();

        Vector3 v = rb.linearVelocity;
        v.y = 0f;
        rb.linearVelocity = v;

        Vector3 boostDir = player.gravityDir.normalized;
        rb.AddForce(boostDir * boostForce, ForceMode.VelocityChange);
    }
}
