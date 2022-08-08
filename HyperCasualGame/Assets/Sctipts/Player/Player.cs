using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject[] upgrades;
    private float size = 1;
    private float height = 1;

    private void Start()
    {
        foreach (var upgrade in upgrades)
        {
            upgrade.GetComponent<Upgrade>().Upgraded += ChangeSize;
        }
    }

    private void ChangeSize(bool increaseOrDicrease, float amount, bool plusOrMinus, bool _size)
    {
        if (_size)
        {
            size = ChangeAttribute(increaseOrDicrease, plusOrMinus, size, amount);
            transform.localScale = new Vector3(size, transform.localScale.y, size);
        }
        else
        {
            height = ChangeAttribute(increaseOrDicrease, plusOrMinus, height, amount);
            transform.localScale = new Vector3(transform.localScale.x, height, transform.localScale.z);
            transform.position = new Vector3(transform.position.x, height, transform.position.z);
        }
    }

    private float ChangeAttribute(bool add, bool plusOrminus, float attribute, float amount)
    {
        if (add)
        {
            if (plusOrminus)
            {
                attribute += amount;
            }
            else
            {
                attribute *= amount;
            }
        }
        else
        {
            if (plusOrminus)
            {
                attribute -= amount;
            }
            else
            {
                attribute /= amount;
            }
        }
        return attribute;
    }
}
