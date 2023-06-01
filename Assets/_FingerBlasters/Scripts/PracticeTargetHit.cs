using UnityEngine;

namespace _FingerBlasters.Scripts
{
    public class PracticeTargetHit : MonoBehaviour
    {
        [SerializeField] public Material hitMaterial;
        [SerializeField] public Material originalMaterial;
        public Renderer renderer;

        void Start()
        {
            renderer = GetComponent<Renderer>();
            renderer.material = originalMaterial;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Arrow"))
            {
                renderer.material = hitMaterial;
                Invoke("TargetBackOn",6f);
            }
        }

        void TargetBackOn()
        {
            //turns the target back on
            renderer.material = originalMaterial;
        }
    }
}