using UnityEngine;
using UnityEngine.SceneManagement;

public class GM_Game : MonoBehaviour
{
    public GameObject goalUIPanel;
    public int currentLevel;
    public string nextSceneName;

    private bool cleared = false;

    private void Start()
    {
        if (goalUIPanel != null)
            goalUIPanel.SetActive(false);
    }

    public void OnGoalReached()
    {
        if (cleared) return;
        cleared = true;

        SaveManager.Instance.SaveLevelClear(currentLevel);

        if (goalUIPanel != null)
            goalUIPanel.SetActive(true);
    }

    public void GoNextLevel()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MainUIScene");
    }
}
