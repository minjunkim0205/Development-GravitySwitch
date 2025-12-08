using UnityEngine;

public class PlayerPadDetector : MonoBehaviour
{
    private PC_Game player;

    private void Awake()
    {
        player = GetComponentInParent<PC_Game>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (player == null) return;

        var pad = other.GetComponentInParent<IUsablePad>();

        if (pad != null)
        {
            player.currentPad = pad;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (player == null) return;

        var pad = other.GetComponentInParent<IUsablePad>();

        if (pad != null && player.currentPad == pad)
        {
            player.currentPad = null;
        }
    }
}
