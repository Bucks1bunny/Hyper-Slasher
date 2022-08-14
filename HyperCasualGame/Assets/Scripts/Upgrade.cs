using System;
using UnityEngine;
using TMPro;

public class Upgrade : MonoBehaviour
{
    public event Action<float, EUpgradeType> InUpgradeEntered = delegate { };

    [SerializeField]
    private EUpgradeType upgradeType;
    [SerializeField]
    private float amount;
    [SerializeField]
    private TextMeshProUGUI amountText;
    [SerializeField]
    private TextMeshProUGUI attributeText;

    private void Start()
    {
        switch (upgradeType)
        {
            case EUpgradeType.SizePlus:
                amountText.text = "+" + amount.ToString();
                attributeText.text = "Size";
                SetColor(Color.green, new Color(0, 1, 0, 0.3f));
                break;
            case EUpgradeType.SizeMinus:
                amountText.text = "-" + amount.ToString();
                attributeText.text = "Size";
                SetColor(Color.red, new Color(1, 0, 0, 0.3f));
                break;
            case EUpgradeType.HeightPlus:
                amountText.text = "+" + amount.ToString();
                attributeText.text = "Height";
                SetColor(Color.green, new Color(0, 1, 0, 0.3f));
                break;
            case EUpgradeType.HeightMinus:
                amountText.text = "-" + amount.ToString();
                attributeText.text = "Height";
                SetColor(Color.red, new Color(1, 0, 0, 0.3f));
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InUpgradeEntered(amount, upgradeType);
        }
        Destroy(gameObject);
    }

    private void SetColor(Color textColor, Color doorColor)
    {
        var material = gameObject.GetComponent<Renderer>();
        material.material.color = doorColor;
        amountText.color = textColor;
    }
}
