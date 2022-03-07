using Actor.Player;
using Managers;
using UI.Controllers;
using UnityEngine;

namespace Environment
{
    public class RemovableRock : MonoBehaviour
    {
        private float lootChance = 40;
        
        private PlayerController _playerController;
        private HUDController _hudController;
        private SoundManager _soundManager;

        void Awake() {
            // _hudController = UIManager.Instance.GetHudController();
            // Debug.Log("RemovableRock AWAKE " + _hudController?.GetInstanceID());
        }

        void Start() {
            _playerController = FindObjectOfType<PlayerController>();
            _soundManager = FindObjectOfType<SoundManager>();
        }

        void OnCollisionEnter2D(Collision2D collision) {
            // TODO: Find a better way to do this logic. Maybe use a "Player" Tag. 
            if (collision.gameObject.CompareTag("Player")) {
                // _playerController = collision.gameObject.GetComponent<PlayerController>();
                // if (_playerController.pickQuantity > 0) {
                //     _soundManager.RemoveRock();
                //
                //     if (Random.Range(0f, 100f) < this.lootChance) {
                //         _soundManager.GoldFound();
                //         float gold = Mathf.Floor(Random.Range(0f, 20f));
                //         _playerController.score += gold;
                //         UIManager.Instance.GetHudController().ShowFloatingText(transform.position, "Gold +" + gold, Color.yellow);
                //     }
                //     
                //     _playerController.AddPick(-1);
                //     Destroy(gameObject);
                // } else {
                //     UIManager.Instance.GetHudController().ShowText("Find a pick!");
                // }
            }
        }
    }
}
