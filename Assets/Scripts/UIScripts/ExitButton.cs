using UnityEngine;
using UnityEngine.SceneManagement;
public class ExitButton : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene(0);
        Debug.Log(Time.timeScale);
        Debug.Log(GamePause.isPause);
    }
}
