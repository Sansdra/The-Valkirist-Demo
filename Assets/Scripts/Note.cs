using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    private bool enteredOkZone = false;
    private bool enteredGoodZone = false;
    private bool enteredPerfectZone = false;

    public int lane;

    public void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            case "OkZone":
                enteredOkZone = true;
                break;
            case "GoodZone":
                enteredGoodZone = true;
                break;
            case "PerfectZone":
                enteredPerfectZone = true;
                break;
        }
    }

    public string GetHitAccuracy()
    {
        if (enteredPerfectZone && enteredGoodZone && enteredOkZone)
            return "Perfect";
        else if (enteredGoodZone && enteredOkZone)
            return "Good";
        else if (enteredOkZone)
            return "Ok";
        else
            return "Miss";
    }
}
