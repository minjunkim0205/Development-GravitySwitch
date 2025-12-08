using UnityEngine;

public class GravityPad : MonoBehaviour, IUsablePad
{
    public void OnUse(PC_Game player)
    {
        // 중력 반전
        player.gravityDir = -player.gravityDir;
        Debug.Log("Gravity reversed!");
    }
}
