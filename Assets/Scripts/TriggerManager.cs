using UnityEngine;

public class TriggerManager : MonoBehaviour
{
    [Header("Triggers in Order")]
    public GameObject[] triggerZones; // Assign Trigger1, Trigger2, Trigger3 in Inspector

    [Header("Teleports in Order")]
    public GameObject[] teleportAreas; // Assign Teleport1, Teleport2 in Inspector

    private int currentTriggerIndex = 0;
    private int currentTeleportIndex = 0;
    public GameObject door;
    public GameObject congratulationsUI;

    void Start()
    {
        // Enable only the first trigger
        for (int i = 0; i < triggerZones.Length; i++)
        {
            triggerZones[i].SetActive(i == 0);
        }

        // Disable all teleports initially
        foreach (GameObject tp in teleportAreas)
            tp.SetActive(false);
    }

    // Called by each trigger when player enters
    public void TriggerEntered(GameObject trigger)
    {
        if (triggerZones[currentTriggerIndex] == trigger)
        {
            Debug.Log("Trigger " + (currentTriggerIndex + 1) + " completed!");
            trigger.SetActive(false); // optional: disable trigger after passing

            currentTriggerIndex++;

            if (currentTriggerIndex < triggerZones.Length)
            {
                // Enable next trigger
                triggerZones[currentTriggerIndex].SetActive(true);
            }
            else
            {
                Debug.Log("All triggers cleared! Teleports unlocked.");
                // Enable first teleport
                if (teleportAreas.Length > 0)
                    teleportAreas[0].SetActive(true);
            }
        }
        if (currentTriggerIndex == triggerZones.Length && door != null)
        {
            door.SetActive(false);
        }
    }

    // Called by each teleport when player enters
    public void TeleportEntered(GameObject teleport)
    {
        if (teleportAreas[currentTeleportIndex] == teleport)
        {
            Debug.Log("Teleport " + (currentTeleportIndex + 1) + " used!");
            teleport.SetActive(false); // optional: disable after use
            currentTeleportIndex++;

            if (currentTeleportIndex < teleportAreas.Length)
            {
                // Enable next teleport
                teleportAreas[currentTeleportIndex].SetActive(true);
            }
            else
            {
                Debug.Log("Tutorial Completed!");
            }
            if (currentTeleportIndex == teleportAreas.Length && congratulationsUI != null)
            {
                congratulationsUI.SetActive(true);
            }
        }
    }
}