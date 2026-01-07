using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    [SerializeField] private GameObject brokenWallPrefab;

    private bool isBroken = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (isBroken) return;

        if (collision.gameObject.CompareTag("Bullet"))
        {
            Break();
        }
    }

    private void Break()
    {
        isBroken = true;

        Instantiate(
            brokenWallPrefab,
            transform.position,
            transform.rotation
        );

        Destroy(gameObject);
    }
}
