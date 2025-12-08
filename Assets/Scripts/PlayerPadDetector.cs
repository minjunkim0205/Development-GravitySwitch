using UnityEngine;

public class PlayerPadDetector : MonoBehaviour
{
    private PC_Game player;

    private void Awake()
    {
        player = GetComponentInParent<PC_Game>();
        Debug.Log("PlayerPadDetector 초기화됨. Player = " + player.name);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter 발생: " + other.name);

        if (player == null) return;

        var pad = other.GetComponentInParent<IUsablePad>();

        if (pad != null)
        {
            player.currentPad = pad;
            Debug.Log("패드 감지됨: " + pad);
        }
        else
        {
            Debug.Log("패드 아님: " + other.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("OnTriggerExit 발생: " + other.name);

        if (player == null) return;

        var pad = other.GetComponentInParent<IUsablePad>();

        if (pad != null && player.currentPad == pad)
        {
            player.currentPad = null;
            Debug.Log("패드에서 벗어남");
        }
    }
}
