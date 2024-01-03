using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Scene
{
    public class Intro_UI : BaseUI
    {
        private Image _introImage;
        private Button _startBtn;
        private TextMeshProUGUI _startBtnText;
        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;
            SetupImage();
            SetupButton();
            SetupText();
            return true;
        }

        private void SetupText()
        {
            SetUI<TextMeshProUGUI>();
            _startBtnText = GetUI<TextMeshProUGUI>(Literals.INTRO_STARTBTN_TEXT);
            _startBtnText.text = "게임 종료";
        }

        private void SetupImage()
        {
            SetUI<Image>();
            _introImage = GetUI<Image>(Literals.INTRO_SPRITE);
        }

        private void SetupButton()
        {
            SetUI<Button>();
            _startBtn = GetUI<Button>(Literals.INTRO_STARTBTN);
        }
    }
}