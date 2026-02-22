using UnityEngine;

public class Trigger : MonoBehaviour
{
    public TriggerManager manager; // assign in inspector

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            manager.TriggerEntered(gameObject);
        }
    }
}