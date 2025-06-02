using UnityEngine;

public class HaloSpawnerAzul : MonoBehaviour
{
    public GameObject haloPrefab;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(haloPrefab, transform.position, Quaternion.identity);
        }
   
    }
}
