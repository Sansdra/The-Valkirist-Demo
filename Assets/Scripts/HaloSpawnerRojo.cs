using UnityEngine;

public class HaloSpawnerRojo : MonoBehaviour
{
    public GameObject haloPrefabR;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Instantiate(haloPrefabR, transform.position, Quaternion.identity);
        }
   
    }
}
