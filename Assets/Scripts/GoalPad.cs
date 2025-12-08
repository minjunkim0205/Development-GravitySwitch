using UnityEngine;

public class GoalPad : MonoBehaviour, IUsablePad
{
    public void OnUse(PC_Game player)
    {
        GM_Game gm = FindAnyObjectByType<GM_Game>();
        gm?.OnGoalReached();
    }
}
