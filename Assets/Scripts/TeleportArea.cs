using UnityEngine;

public class TeleportArea : MonoBehaviour
{
    public TriggerManager manager; // assign in inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.TeleportEntered(gameObject);
        }
    }
}