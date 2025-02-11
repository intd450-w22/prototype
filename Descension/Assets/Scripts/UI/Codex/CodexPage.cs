﻿using System;
using System.Collections.Generic;
using Rules;
using UnityEngine;

namespace UI.Codex
{
    // Inspector compatible component for creating pickups
    [Serializable]
    public class CodexPage
    {
        public string PageTitle;
        public CodexPageType PageType;
        public List<CodexPageItem> PageItems;
    }

    [Serializable]
    public class CodexPageItem
    {
        public string ItemName;
        [TextArea(5,10)]
        public string ItemDescription;
        public Sprite ItemSprite;
        public Rule Rule;
    }

}