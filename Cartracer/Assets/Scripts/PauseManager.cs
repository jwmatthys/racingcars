using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private bool isPaused = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                isPaused = false;
                OnResumePressed();
            }
            else
            {
                isPaused = true;
                OnPausePressed();
            }
        }
    }

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
