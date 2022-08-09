using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gem")
        {
            int gems = PlayerPrefs.GetInt("Gems");
            PlayerPrefs.SetInt("Gems", gems++);
        }
    }
}
