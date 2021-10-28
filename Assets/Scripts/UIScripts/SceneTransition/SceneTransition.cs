using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Audio;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private AudioMixerSnapshot snapMute;
    [SerializeField] private GameObject animator;
    private static SceneTransition sceneTransition;
    private static Animator animatorTap;
    private static AudioMixerSnapshot backMusic;
    private AsyncOperation loadingScene;
    
    private void Start()
    {
        sceneTransition = this;
        animatorTap = animator.GetComponent<Animator>();
        backMusic = snapMute;
    }
    public static IEnumerator LoadScene(int sceneIndex)
    {
        yield return null;
        backMusic.TransitionTo(0);
        sceneTransition.loadingScene = SceneManager.LoadSceneAsync(sceneIndex);
        sceneTransition.loadingScene.allowSceneActivation = false;
        while (!sceneTransition.loadingScene.isDone)
        {
            sceneTransition.progressBar.value = Mathf.Lerp(sceneTransition.progressBar.value, sceneTransition.loadingScene.progress + 0.1f, Time.deltaTime * 5);
            if (sceneTransition.loadingScene.progress >= 0.9f)
            {
                animatorTap.SetTrigger("StartBlink");
                if (Input.GetMouseButtonDown(0))
                    sceneTransition.loadingScene.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
