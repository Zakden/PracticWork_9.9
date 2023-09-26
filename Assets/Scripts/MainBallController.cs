using UnityEngine;

public class MainBallController : MonoBehaviour
{
    private Rigidbody rb;

    public Transform Target;
    public float Power;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Vector3 direction = Target.position - transform.position;
        rb.AddForce(direction.normalized * Power, ForceMode.Impulse);
    }
}
