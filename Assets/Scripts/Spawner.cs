using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Point;
    public MeshCollider Plane;

    float x, z;

    Vector3 SpawnPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartPos();
    }

    void StartPos()
    {
        x = Random.Range(Plane.transform.position.x - Random.Range(0, Plane.bounds.extents.x), Plane.transform.position.x + Random.Range(0, Plane.bounds.extents.x));
        z = Random.Range(Plane.transform.position.z - Random.Range(0, Plane.bounds.extents.z), Plane.transform.position.z + Random.Range(0, Plane.bounds.extents.z));
        SpawnPos = new Vector3(x, 0.5f, z);
        GameObject player = Instantiate(Point, SpawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        StartPos();
    }
}
