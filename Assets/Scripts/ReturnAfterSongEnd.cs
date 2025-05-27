using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ReturnAfterSongEnd : MonoBehaviour
{
    public AudioSource audioSource;

    private bool hasReturned = false;

    void Update()
    {
        if (!hasReturned && !audioSource.isPlaying && audioSource.time > 0)
        {
            hasReturned = true;
            StartCoroutine(ReturnAfterDelay());
        }
    }

    IEnumerator ReturnAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        SceneTransitionManager.Instance.ReturnToPreviousScene();
    }
}
