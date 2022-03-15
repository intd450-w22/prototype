using Items.Pickups;
using Managers;
using UnityEngine;

namespace Items
{
    public class ItemSpawner : MonoBehaviour
    {
        public GameObject pickPickupPrefab;
        public GameObject bowPickupPrefab;
        public GameObject swordPickupPrefab;
        public GameObject arrowsPickupPrefab;

        private static ItemSpawner _instance;
        public static ItemSpawner Instance
        {
            get
            {
                if (_instance == null) _instance = FindObjectOfType<ItemSpawner>();
                return _instance;
            }
        }
        
        void Awake()
        {
            if (_instance == null) _instance = this;
            else if (_instance != this) Destroy(gameObject);
            DontDestroyOnLoad(gameObject);
        }

        public void DropItem(GameObject prefab, int quantity)
        {
            // spawn pickup
            SoundManager.Instance.ItemFound(); // TODO maybe replace with unique item drop sound
            GameObject pickupObject = Instantiate(prefab, GameManager.PlayerController.transform.position, Quaternion.identity);
            Pickup pickup = pickupObject.GetComponent<Pickup>();
            pickup.quantity = quantity;
            UIManager.Instance.GetHudController().ShowText(pickup.item.GetName() + " Dropped");
        }
    }
}