using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public GameObject target;
    private Vector3 offset = new Vector3(7,5,-8);

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = target.transform.position + offset;
    }
}
