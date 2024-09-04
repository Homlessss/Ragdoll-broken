using UnityEngine;
using System.Collections;

public class ApplyForceOnCollision : MonoBehaviour
{
    public float      force = 5f;
    public GameObject character;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody == null)
        {
            Debug.LogWarning("Va chạm không có Rigidbody.");
            return;
        }
        
        float collisionForce = collision.relativeVelocity.magnitude * collision.rigidbody.mass;
        
        if (character == null)
        {
            Debug.LogError("Đối tượng nhân vật chưa được gán.");
            return;
        }
        
        TriggerRagdoll ragdollScript = character.GetComponent<TriggerRagdoll>();
        
        if (collisionForce > force)
        {
            if (ragdollScript != null)
            {
                ragdollScript.EnableRagdoll();
                StartCoroutine(PauseGameAfterDelay(5f));
                Debug.Log("Complete");
            }
        }
    }
    
    private IEnumerator PauseGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); 
        Time.timeScale = 0f; 
    }
}
