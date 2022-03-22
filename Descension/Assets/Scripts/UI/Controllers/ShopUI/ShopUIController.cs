using System;
using System.Collections.Generic;
using Items.Pickups;
using Managers;
using TMPro;
using UI.Controllers.ButtonController;
using UnityEngine;
using Util.Helpers;

namespace UI.Controllers.ShopUI
{
    public class ShopUIController : MonoBehaviour
    {
        public String goldText = "Gold: ";
        public GameObject shopMenuItemPrefab;
        public List<ShopItem> shopItems;  // Items set here will be spawned as menu items automatically on start

        [HideInInspector] public List<GameObject> spawned;
        private TMP_Text _goldText;
        private TMP_Text _feedbackText;

        private Transform _menuRoot;
        public Transform MenuRoot
        {
            get
            {
                if (_menuRoot == null) _menuRoot = gameObject.GetChildObjectWithName("ShopItems").transform;
                return _menuRoot;
            }
        }
        
        void Awake()
        {
            _goldText = gameObject.GetChildObjectWithName("ShopItems").GetChildObjectWithName("GoldText").GetComponent<TMP_Text>();
            _feedbackText = gameObject.GetChildObjectWithName("ShopItems").GetChildObjectWithName("FeedbackText").GetComponent<TMP_Text>();
        }

        void Start()
        {
            foreach (ShopItem shopItem in shopItems)
            {
                if (shopItem.item != null)
                {
                    GameObject menuItem = Instantiate(shopMenuItemPrefab, MenuRoot);
                    menuItem.GetComponent<ShopItemButtonController>().Set(shopItem.item, shopItem.cost);
                    menuItem.name = shopItem.item.GetName() + "MenuItem";
                    menuItem.transform.SetAsLastSibling();
                }
            }
            gameObject.GetChildObjectWithName("ShopItems").GetChildObjectWithName("ReturnMenuItem").transform.SetAsLastSibling();
        }

        public void UpdateGold()
        {
            _goldText.text = goldText + " " + InventoryManager.Gold;
        }

        public void DisplayFeedback(String text)
        {
            _feedbackText.text = text;
            CancelInvoke(nameof(ClearFeedbackText));
            Invoke(nameof(ClearFeedbackText), 3);
        }

        private void ClearFeedbackText()
        {
            _feedbackText.text = "";
        }
    }
    
    
    [Serializable]
    public struct ShopItem
    {
        public EquippableItem item;
        public int cost;
    }
}
