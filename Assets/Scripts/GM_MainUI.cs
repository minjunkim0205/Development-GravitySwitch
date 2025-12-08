using UnityEngine;
using UnityEngine.SceneManagement;

public class GM_MainUI : MonoBehaviour
{
    public static GM_MainUI Instance;

    public GameObject panelMainUI;
    public GameObject panelSelectLevelUI;
    public GameObject panelSettingUI;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowSelectLevel()
    {
        panelMainUI.SetActive(false);
        panelSettingUI.SetActive(false);
        panelSelectLevelUI.SetActive(true);

        LevelSelectUI.Instance.RefreshLevelStatus();
    }

    public void ShowSetting()
    {
        panelMainUI.SetActive(false);
        panelSelectLevelUI.SetActive(false);
        panelSettingUI.SetActive(true);
    }

    public void BackToMain()
    {
        panelMainUI.SetActive(true);
        panelSelectLevelUI.SetActive(false);
        panelSettingUI.SetActive(false);
    }

    public void StartLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif    
    }
}
