using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<int> GemPickedup = delegate { };

    public int Gems
    {
        get;
        private set;
    } = 0;
    public AudioSource Audio
    {
        get;
        private set;
    }

    [SerializeField]
    private AudioClip gemPickupSound;
    private float size = 1.5f;
    private float height = 1.5f;

    private void Start()
    {
        var upgradeGO = GameObject.Find("Upgrades");
        foreach (var upgrade in upgradeGO.GetComponentsInChildren<Upgrade>())
        {
            upgrade.InUpgradeEntered += OnUpgradeEntered;
        }
        Audio = GetComponent<AudioSource>();

    }

    private void OnUpgradeEntered(float amount, EUpgradeType upgradeType)
    {
        amount /= 100;
        switch (upgradeType)
        {
            case EUpgradeType.SizePlus:
                size += amount;
                transform.localScale = new Vector3(size, transform.localScale.y, size);
                break;
            case EUpgradeType.SizeMinus:
                size -= amount;
                transform.localScale = new Vector3(size, transform.localScale.y, size);
                break;
            case EUpgradeType.HeightPlus:
                height += amount;
                transform.localScale = new Vector3(transform.localScale.x, height, transform.localScale.z);
                break;
            case EUpgradeType.HeightMinus:
                height -= amount;
                transform.localScale = new Vector3(transform.localScale.x, height, transform.localScale.z);
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Gem")
        {
            Gems += 1;
            GemPickedup(Gems);
            Audio.clip = gemPickupSound;
            Audio.Play();
            Destroy(other.gameObject);
        }
    }
}
