using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ControlPlayer : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

    public GameObject Point;
    public MeshCollider Plane;
    public GameObject Wasted;

    float x, z;

    Vector3 SpawnPos;

    void Start()
    {
        Wasted.gameObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate() // NOW: void Update () {
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(-moveVertical, 0.0f, moveHorizontal);
        rb.AddForce(movement * speed);
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Wasted.gameObject.SetActive(false);
            SceneManager.LoadScene("SampleScene");
            Time.timeScale = 1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point"))
        {
            Destroy(other.gameObject);
            StartPos();
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
            Wasted.gameObject.SetActive(true);

        }
    }


    void StartPos()
    {
        x = Random.Range(Plane.transform.position.x - Random.Range(0, Plane.bounds.extents.x), Plane.transform.position.x + Random.Range(0, Plane.bounds.extents.x));
        z = Random.Range(Plane.transform.position.z - Random.Range(0, Plane.bounds.extents.z), Plane.transform.position.z + Random.Range(0, Plane.bounds.extents.z));
        SpawnPos = new Vector3(x, 0.5f, z);
        GameObject player = Instantiate(Point, SpawnPos, Quaternion.identity);
    }
}
