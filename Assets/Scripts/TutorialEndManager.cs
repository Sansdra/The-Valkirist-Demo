using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class TutorialEndManager : MonoBehaviour
{
    public AudioSource musicSource;
    public string returnSceneName = "Habitacion";
    private bool endTriggered = false;

    void Update()
    {
        if (!endTriggered && musicSource != null && !musicSource.isPlaying && musicSource.time > 1f)
        {
            endTriggered = true;
            StartCoroutine(ReturnAfterDelay(3f));
        }
    }

    IEnumerator ReturnAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(returnSceneName);
    }
}
