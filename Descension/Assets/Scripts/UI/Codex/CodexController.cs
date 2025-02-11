﻿using System.Collections.Generic;
using System.Linq;
using UI.UI;
using UnityEngine;
using Util.Helpers;

namespace UI.Codex
{
    public class CodexController : UIController
    {
        [Header("Page Configuration")] 
        public List<CodexPage> CodexPages; // readonly

        [Header("Prefabs")]
        public GameObject CodexPagePrefab; 
        public GameObject CodexMenuItemPrefab;

        private GameObject _codexPagesContainer;
        private List<CodexPageController> _codexPageControllers = new List<CodexPageController>();

        private CodexPageType? _currPageType;

        void Awake()
        {
            if (CodexPagePrefab == null)
                GameDebug.LogWarning("Codex: CodexPagePrefab not set.");
            if(CodexMenuItemPrefab == null)
                GameDebug.LogWarning("Codex: CodexMenuItemPrefab not set.");
            if(CodexPages.IsNullOrEmpty())
                GameDebug.LogWarning("Codex: No pages found.");

            _codexPagesContainer = gameObject.GetChildObject("CodexPages");
            if (_codexPagesContainer == null || _codexPagesContainer.transform == null)
                GameDebug.LogWarning("Codex: Can't find 'CodexPages' game object.");

            foreach (var page in CodexPages)
                CreatePage(page);

            _codexPageControllers.ForEach(x => x.Deactivate());
            SetPage(CodexPages.First().PageType);
        }

        public override void OnStart() => _codexPageControllers.ForEach(x => x.OnStart());
        public bool CheckFacts() => _codexPageControllers.Aggregate(false, (current, page) => current | page.CheckFacts());

        public void CreatePage(CodexPage page)
        {
            // instantiate prefab as child of CodexPages
            var pageGameObject = Instantiate(CodexPagePrefab, _codexPagesContainer.transform);
            pageGameObject.name = page.PageType + "Page";
            pageGameObject.transform.SetAsLastSibling();

            // set values 
            var pageController = pageGameObject.GetComponent<CodexPageController>();
            pageController.CodexMenuItemPrefab = CodexMenuItemPrefab;
            pageController.Init(page);

            // add reference to _codexPageControllers
            _codexPageControllers.Add(pageController);
        }

        public void SetPage(CodexPageType pageType)
        {
            if (_currPageType != null)
                _codexPageControllers.SingleOrDefault(x => x.PageType == _currPageType)?.Deactivate();

            var page = _codexPageControllers.SingleOrDefault(x => x.PageType == pageType);
            if (page != null)
            {
                page.Activate();
                _currPageType = pageType;
            }
            else GameDebug.LogWarning($"No page in codex of type {pageType}");
        }
    }
}