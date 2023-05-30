using UnityEngine;

namespace _FingerBlasters.Scripts
{
    public class HitTarget : MonoBehaviour
    {
        private Rigidbody targetRigidbody;

        [SerializeField] private Material hitMaterial;    
        private void Start()
        {
            targetRigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Arrow"))
            {
                targetRigidbody.GetComponent<Renderer>().material = hitMaterial;
                Debug.Log("the target was hit!");
                targetRigidbody.isKinematic = false;
                targetRigidbody.useGravity = true;
                Destroy(targetRigidbody.gameObject, 5f);
            }
        }
    }
}