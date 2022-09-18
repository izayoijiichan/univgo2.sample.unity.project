#nullable enable
namespace UniVgoDemos
{
    using System;
    using System.IO;
    using UnityEngine;
    using UniVgo2;

    public class RuntimeLoadBehaviour : MonoBehaviour
    {
        [SerializeField]
        private string _LocalFilePath = string.Empty;

        private IDisposable? _ModelAssetDisposer = null;
        
        private void Start()
        {
            if (File.Exists(_LocalFilePath))
            {
                var vgoImporter = new VgoImporter();

                ModelAsset modelAsset = vgoImporter.Load(_LocalFilePath);

                vgoImporter.ReflectSkybox(Camera.main, modelAsset);

                _ModelAssetDisposer = modelAsset;
            }
            else
            {
                Debug.LogWarningFormat("File is not found. {0}", _LocalFilePath);
            }
        }

        private void OnDestroy()
        {
            _ModelAssetDisposer?.Dispose();
        }
    }
}
