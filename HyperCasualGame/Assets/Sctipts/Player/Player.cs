using UnityEngine;

public class Player : MonoBehaviour
{
    private GameObject[] upgrades;
    private float size = 1;
    private float height = 1;

    private void Start()
    {
        var upgradeGO = GameObject.Find("Upgrades");
        foreach (var upgrade in upgradeGO.GetComponentsInChildren<Upgrade>())
        {
            upgrade.Upgraded += ChangeSize;
        }
    }

    private void ChangeSize(bool _size, float amount,EUpgradeType upgradeType)
    {
        if (_size)
        {
            size = ChangeAttribute(size, amount,upgradeType);
            transform.localScale = new Vector3(size, transform.localScale.y, size);
        }
        else
        {
            height = ChangeAttribute(height, amount, upgradeType);
            transform.localScale = new Vector3(transform.localScale.x, height, transform.localScale.z);
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
        }
    }

    private float ChangeAttribute(float attribute, float amount, EUpgradeType upgradeType)
    {
        amount /= 10;
        switch (upgradeType)
        {
            case EUpgradeType.IncreaseAndPlus:
                attribute += amount;
                break;
            case EUpgradeType.IncraeseAndMultiply:
                attribute *= amount;
                break;
            case EUpgradeType.DecreaseAndMinus:
                attribute -= amount;
                break;
            case EUpgradeType.DecreaseAndDivide:
                attribute /= amount;
                break;
        }
        return attribute;
    }
}
