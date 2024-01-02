using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class Minimap_UI : BaseUI
    {
        [SerializeField] private GameObject player;
        [SerializeField] private RenderTexture minimapTexture;
        [SerializeField] private Camera minimapCamera;
        private RawImage _minimap;

        protected override bool Initialized()
        {
            if (!base.Initialized()) return false;
            MinimapCameraSetup();
            MinimapSetup();
            return true;
        }

        private void MinimapCameraSetup()
        {
            minimapCamera.targetTexture = minimapTexture;
        }

        private void MinimapSetup()
        {
            _minimap = GetComponentInChildren<RawImage>();
            _minimap.texture = minimapTexture;
        }
    }
}