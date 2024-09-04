using UnityEngine;

public class TriggerRagdoll : MonoBehaviour
{
    private Rigidbody[] _ragdollRigidbodies;
    // Start is called before the first frame update
    void Awake()
    {
        _ragdollRigidbodies = this.GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();
    }

    private void DisableRagdoll()
    {
        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = true;
        }
    }
    
    public void EnableRagdoll()
    {
        foreach (var rigidbody in _ragdollRigidbodies)
        {
            rigidbody.isKinematic = false;
        }
    }
}
