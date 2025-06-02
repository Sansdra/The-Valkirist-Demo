using UnityEngine;

public class HaloSpawnerVerde : MonoBehaviour
{
    public GameObject haloPrefabR;
    

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Instantiate(haloPrefabR, transform.position, Quaternion.identity);
        }
   
    }
}
