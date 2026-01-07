using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private float lifeTime;
    private float timer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void Init(Vector3 velocity, float lifeTime)
    {
        rb.linearVelocity = velocity;
        this.lifeTime = lifeTime;
        timer = 0f;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= lifeTime)
        {
            BulletPool.Instance.ReturnBullet(gameObject);
        }
    }

    private void OnDisable()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
