using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class BoxKey : MonoBehaviour
{
    public HingeJoint leftPanelHinge;
    public HingeJoint rightPanelHinge;
    public float leftUnlockedMin = -120f;
    public float rightUnlockedMin = -120f;

    private XRSocketInteractor socket;
    private bool unlocked = false;

    void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    void OnEnable()
    {
        socket.selectEntered.AddListener(OnKeyInserted);
    }

    void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnKeyInserted);
    }

    private void OnKeyInserted(SelectEnterEventArgs args)
    {
        if (unlocked) return;
        UnlockBox();
    }

    private void UnlockBox()
    {
        unlocked = true;

        JointLimits leftLimits = leftPanelHinge.limits;
        leftLimits.min = leftUnlockedMin;
        leftPanelHinge.useLimits = false; 
        leftPanelHinge.limits = leftLimits;
        leftPanelHinge.useLimits = true;

        JointLimits rightLimits = rightPanelHinge.limits;
        rightLimits.min = rightUnlockedMin;
        rightPanelHinge.useLimits = false; 
        rightPanelHinge.limits = rightLimits;
        rightPanelHinge.useLimits = true;

    }
}