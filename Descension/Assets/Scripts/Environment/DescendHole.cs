using Actor.Player;
using Managers;
using UI.Controllers;
using Util;
using Util.Enums;
using UnityEngine;

namespace Environment
{
    public class DescendHole : MonoBehaviour
    {
        public Scene nextLevel;
        public string otherLevelName;
        
        private HUDController _hudController;

        void Awake()
        {
            _hudController = UIManager.GetHudController();
        }

        void OnCollisionEnter2D(Collision2D collision) {
            if (collision.gameObject.CompareTag("Player")) {
                if (GameManager.PlayerController.ropeQuantity > 0) {
                    GameManager.PlayerController.AddRope(-1);
                    UIManager.GetHudController().ShowText("Descend to level two...");

                    if(nextLevel == Scene.Other)
                        SceneLoader.Load(otherLevelName);
                    else if (nextLevel == Scene.Level3)
                        UIManager.SwitchUi(UIType.End);
                    else
                        SceneLoader.Load(nextLevel.ToString());   
                    
                } else {
                    UIManager.GetHudController().ShowText("You need a rope in order to descend");
                }
            }
        }
    }
}
