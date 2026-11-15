using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        transform.LookAt(target);
    }
}
