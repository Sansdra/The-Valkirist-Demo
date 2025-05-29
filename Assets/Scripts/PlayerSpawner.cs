using Unity.VisualScripting;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public Transform spawnPoint;

    GameObject ErinRoot;

    void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null && spawnPoint != null)
        {
            ErinRoot = GameObject.Find("ErinRoot");

            ErinRoot.transform.position = spawnPoint.position;
            ErinRoot.transform.rotation = spawnPoint.rotation;

            //player.transform.position = spawnPoint.position;
            //player.transform.rotation = spawnPoint.rotation;
        }
        else
        {
            Debug.LogWarning("Player o spawnPoint no encontrados.");
        }
    }
}
