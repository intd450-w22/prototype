using Actor.Player;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace Environment
{
    public class PostProcessingScript : MonoBehaviour
    {
        public PostProcessVolume volume;
        private Vignette vignette;

        void Start() {
            volume.profile.TryGetSettings(out vignette);
            vignette.intensity.value = 1f;
            vignette.enabled.value = true;
        }

        void Update() {
            if (FindObjectOfType<PlayerController>().TorchQuantity > 0) {
                vignette.intensity.value = 0.5f;
            } else {
                vignette.intensity.value = 1f;
            }
        }
    }
}
