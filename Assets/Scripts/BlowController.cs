using UnityEngine;

public class BlowController : MonoBehaviour
{
    public float TimeToExplosion;
    public float Power;
    public float Radius;
    
    void Update()
    {
        TimeToExplosion -= Time.deltaTime;
        if(TimeToExplosion <= 0)
            Boom();
    }

    void Boom()
    {
        Rigidbody[] blocks = FindObjectsOfType<Rigidbody>();
        
        foreach(Rigidbody b in blocks) 
        {
            if(Vector3.Distance(transform.position, b.transform.position) < Radius)
            {
                Vector3 direction = b.transform.position - transform.position;
                b.AddForce(direction.normalized * Power * (Radius - Vector3.Distance(transform.position, b.transform.position)), ForceMode.Impulse);
            }
        }
        TimeToExplosion = 3;
    }
}
