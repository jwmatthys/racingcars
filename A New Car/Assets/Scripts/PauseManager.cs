using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public void OnQuitPressed()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void OnPausePressed()
    {
        Time.timeScale = 0;
    }

    public void OnResumePressed()
    {
        Time.timeScale = 1;
    }
}
