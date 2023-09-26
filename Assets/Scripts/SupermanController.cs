using UnityEngine;

public class SupermanController : MonoBehaviour
{
    const int BadGuyLayer = 7; // Номер слоя врагов
    const float Distance = 0.66f; // Дистанция между Суперменом и Врагом при которой ГГ переключается на следующего врага

    public Transform[] Enemies;
    public Vector3 FinishPosition;

    public float Power;
    public float Speed;

    private int target = 0;
    private Rigidbody rigBody;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == BadGuyLayer)
        {
            if (collision.rigidbody != null)
            {
                Vector3 direction = collision.transform.position - transform.position;
                collision.rigidbody.AddForce(direction.normalized * Power * Speed, ForceMode.Impulse);
            }
        }
    }

    private void Start()
    {
        rigBody = GetComponent<Rigidbody>();
        transform.position = Vector3.MoveTowards(transform.position, Enemies[target].position, Speed);
        transform.LookAt(Enemies[target].position);
    }

    private void FixedUpdate()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        if (target == Enemies.Length + 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, FinishPosition, Speed * Time.deltaTime);
            transform.LookAt(FinishPosition);
            if (transform.position == FinishPosition)
            {
                rigBody.velocity = Vector3.zero;
                rigBody.angularVelocity = Vector3.zero;
            }
        }
        else if (target <= Enemies.Length)
        {
            transform.LookAt(Enemies[target].transform.position);
            transform.position = Vector3.MoveTowards(transform.position, Enemies[target].position, Speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, Enemies[target].position) < Distance)
            {
                if (target >= Enemies.Length - 1)
                    target = Enemies.Length + 1;
                else
                    target++;
            }
        }
    }
}
