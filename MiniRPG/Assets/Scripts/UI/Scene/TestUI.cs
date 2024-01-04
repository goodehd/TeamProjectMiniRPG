using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Scene
{
    public class TestUI : BaseUI
    {
        public Image Skill1 { get; private set; }
        public Image Skill2 { get; private set; }

        public Button btn { get; private set; }
        public SkillTooltip_UI Skill1Tooltip;


        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;
            SetupImage();
            SetupButton();
            return true;
        }

        private void SetupButton()
        {
            SetUI<Button>();
            btn = GetUI<Button>("Button");
            btn.gameObject.SetEvent(UIEventType.Click, LoadingPage);
        }

        private void LoadingPage(PointerEventData data)
        {

            string label = "Game";
            Main.NextScene = "Game";
            Main.Scenes.LoadLoadingScene();


        }
        private void SetupImage()
        {
            SetUI<Image>();
            Skill1 = GetUI<Image>("Skill1");
            Skill2 = GetUI<Image>("Skill2");
            Skill1.gameObject.SetEvent(UIEventType.PointerEnter, OpenTooltip1);
            Skill2.gameObject.SetEvent(UIEventType.PointerEnter, OpenTooltip2);
        }

        private void OpenTooltip1(PointerEventData data)
        {
            Debug.Log("1번켜짐");
            Skill1Tooltip = UI.SetSubItemUI<SkillTooltip_UI>(Skill1.transform);
            Skill1.gameObject.SetEvent(UIEventType.PointerExit, CloseTooltip1);
        }

        private void CloseTooltip1(PointerEventData data)
        {
            Debug.Log("1번 종료");

            UI.DestroySubItemUI<SkillTooltip_UI>(Skill1Tooltip.gameObject);
        }

        private void OpenTooltip2(PointerEventData data)
        {
            UI.SetSubItemUI<SkillTooltip_UI>(Skill2.transform);
        }
    }
}