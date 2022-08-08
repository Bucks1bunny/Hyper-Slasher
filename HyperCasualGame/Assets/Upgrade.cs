using System;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public event Action<bool, float, bool, bool> Upgraded = delegate { };

    [SerializeField]
    private float amount;
    [SerializeField]
    private bool increase;
    [SerializeField]
    private bool plus;
    [SerializeField]
    private bool size;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Upgraded(increase, amount, plus, size);
        }
        Destroy(gameObject);
    }
}
