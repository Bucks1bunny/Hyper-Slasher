using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    private float offset;

    private void Start()
    {
        offset = transform.position.z;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + offset);
    }
}
