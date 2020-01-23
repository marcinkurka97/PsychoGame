using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    public Animator animator;
    private string levelToLoad;

    public void FadeToLevel(string levelName) {
        levelToLoad = levelName;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() {
        SceneManager.LoadScene(levelToLoad);
    }

    public void Fade() {
        animator.SetTrigger("FadeOut");
    }
}
