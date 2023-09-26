using UnityEngine;

public class SphereController : MonoBehaviour
{
    public Vector3[] PointTo;
    public float Speed;

    private int target = 0;

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, PointTo[target], Time.deltaTime * Speed);
        if (transform.position == PointTo[target])
        {
            target++;
            if (target >= PointTo.Length)
                target = 0;
        }    
    }
}
