using UnityEngine;

public class HaloSpawnerAmarillo : MonoBehaviour
{
    public GameObject haloPrefabR;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Instantiate(haloPrefabR, transform.position, Quaternion.identity);
        }
   
    }
}
