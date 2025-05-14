using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public float speed;

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(this.transform.forward * speed * Time.deltaTime, Space.World);
    }
}
