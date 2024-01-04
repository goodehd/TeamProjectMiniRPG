using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Scene
{
    public class Loading_UI : BaseUI
    {
        private Button _startBtn;
        private TextMeshProUGUI _startBtnText;
        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;
            SetupText();
            return true;
        }

        private void SetupText()
        {
            SetUI<TextMeshProUGUI>();

        }

    }
}