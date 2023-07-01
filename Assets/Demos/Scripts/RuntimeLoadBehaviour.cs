#nullable enable
namespace UniVgoDemos
{
    using System;
    using System.IO;
    using UnityEngine;
    using UniVgo2;

    public class RuntimeLoadBehaviour : MonoBehaviour
    {
        private readonly VgoImporter _VgoImporter = new VgoImporter();

        [SerializeField]
        private string _LocalFilePath = string.Empty;

        private IDisposable? _ModelAssetDisposer = null;
        
        private void Start()
        {
            if (File.Exists(_LocalFilePath))
            {
                VgoModelAsset vgoModelAsset = _VgoImporter.Load(_LocalFilePath);

                _VgoImporter.ReflectSkybox(Camera.main, vgoModelAsset);

                _ModelAssetDisposer = vgoModelAsset;
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
