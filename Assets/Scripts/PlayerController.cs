using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public float speed = 200;
    public float rotationspeed = 200;
    private float horizontalinput;
    private float verticalinput;


    // Update is called once per frame
    void Update()
    {
        horizontalinput = Input.GetAxis("Horizontal");
        verticalinput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalinput);
        transform.Rotate(Vector3.up * Time.deltaTime * rotationspeed * horizontalinput);
    }
}
