using UnityEngine;
using TMPro;

public class LevelSelectUI : MonoBehaviour
{
    public static LevelSelectUI Instance;

    public TMP_Text level1Text;
    public TMP_Text level2Text;
    public TMP_Text level3Text;
    public TMP_Text level4Text;
    public TMP_Text level5Text;

    private void Awake()
    {
        Instance = this;
    }

    public void RefreshLevelStatus()
    {
        var data = SaveManager.Instance.Load();

        level1Text.text = data.level1Clear ? "Level 1 (Clear)" : "Level 1";
        level2Text.text = data.level2Clear ? "Level 2 (Clear)" : "Level 2";
        level3Text.text = data.level3Clear ? "Level 3 (Clear)" : "Level 3";
        level4Text.text = data.level4Clear ? "Level 4 (Clear)" : "Level 4";
        level5Text.text = data.level5Clear ? "Level 5 (Clear)" : "Level 5";
    }

    public void StartLevel1() => GM_MainUI.Instance.StartLevel("Level1");
    public void StartLevel2() => GM_MainUI.Instance.StartLevel("Level2");
    public void StartLevel3() => GM_MainUI.Instance.StartLevel("Level3");
    public void StartLevel4() => GM_MainUI.Instance.StartLevel("Level4");
    public void StartLevel5() => GM_MainUI.Instance.StartLevel("Level5");
}
