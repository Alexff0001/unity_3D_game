using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()  // NOW: void Update () {
    {
        transform.position = player.transform.position + offset;
    }
}

