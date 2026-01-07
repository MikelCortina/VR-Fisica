using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

[RequireComponent(typeof(XRGrabInteractable))]
public class Pistol : MonoBehaviour
{
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float lifeTime = 1f;

    public AudioClip clip;
    private AudioSource audioSource;

    private XRGrabInteractable grabInteractable;
    private int handsGrabbing = 0;

    public bool dobleAgarre;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        audioSource = GetComponent<AudioSource>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        handsGrabbing++;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        handsGrabbing--;
    }

    public void FireBullet()
    {
        if (handsGrabbing < 2 && dobleAgarre)
            return;

        GameObject bullet = BulletPool.Instance.GetBullet();

        bullet.transform.position = firePoint.position;
        bullet.transform.rotation = firePoint.rotation;

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.Init(
            firePoint.forward * bulletSpeed,
            lifeTime
        );

        audioSource.PlayOneShot(clip);
    }
}
