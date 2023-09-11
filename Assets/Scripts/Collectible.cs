using UnityEngine;
using UnityEngine.Events;

public class Collectible : MonoBehaviour
{
    private bool active = true;

    //[SerializeField] private GameObject particlePrefab;
    [SerializeField] private string validTag = "none";
    [SerializeField] private bool debugLog = false;

    private void Awake()
    {
        //OnCollect.AddListener(SpawnParticles);
    }

    public UnityEvent OnCollect = new UnityEvent();

    private void OnTriggerEnter(Collider other)
    {
        if (!active) return;

        if(other.tag == validTag && active)
        {
            OnCollect.Invoke();

            if (debugLog) Debug.Log("On Trigger Enter");
        }

    }

    //private void SpawnParticles()
    //{
        //if (particlePrefab) Instantiate(particlePrefab, transform.position, transform.rotation);
    //}
}
