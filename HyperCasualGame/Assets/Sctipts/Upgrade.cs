using System;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    public event Action<bool, float, EUpgradeType> Upgraded = delegate { };

    [SerializeField]
    private EUpgradeType upgradeType;
    [SerializeField]
    private float amount;
    [SerializeField]
    private bool size;
    [SerializeField]
    private TextMeshProUGUI upgradeText;

    private void Start()
    {
        switch (upgradeType)
        {
            case EUpgradeType.IncreaseAndPlus:
                upgradeText.text = "+" + amount.ToString();
                upgradeText.color = Color.green;
                break;
            case EUpgradeType.IncraeseAndMultiply:
                upgradeText.text = "*" + amount.ToString();
                upgradeText.color = Color.green;
                break;
            case EUpgradeType.DecreaseAndMinus:
                upgradeText.color = Color.red;
                upgradeText.text = "-" + amount.ToString();
                break;
            case EUpgradeType.DecreaseAndDivide:
                upgradeText.text = "/" + amount.ToString();
                upgradeText.color = Color.red;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Upgraded(size, amount, upgradeType);
        }
        Destroy(gameObject);
    }
}
