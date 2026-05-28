using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject levelPanel;

    // Buka panel level
    public void OpenLevelPanel()
    {
        levelPanel.SetActive(true);
    }

    // Tutup panel level
    public void CloseLevelPanel()
    {
        levelPanel.SetActive(false);
    }

    // Load Level 1
    public void LoadLevel1()
    {
        SceneManager.LoadScene("level1");
    }

    // Load Level 2
    public void LoadLevel2()
    {
        SceneManager.LoadScene("level2");
    }

    // Load Level 3
    public void LoadLevel3()
    {
        SceneManager.LoadScene("level3");
    }
}