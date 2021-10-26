using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void ExitButton()
    {
        SceneManager.LoadScene(0);
    }
}
