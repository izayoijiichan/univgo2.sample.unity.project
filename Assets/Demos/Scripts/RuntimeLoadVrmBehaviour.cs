#nullable enable
namespace UniVgoDemos
{
    using System;
    using System.IO;
    using UniGLTF;
    using UnityEngine;
    using VRM;

    public class RuntimeLoadVrmBehaviour : MonoBehaviour
    {
        [SerializeField]
        private string _LocalFilePath = string.Empty;

        private IDisposable? _GltfInstanceDisposer = null;

        private void Start()
        {
            if (File.Exists(_LocalFilePath))
            {
                var parser = new GlbFileParser(_LocalFilePath);

                GltfData gltfData = parser.Parse();

                var vrmData = new VRMData(gltfData);

                using (var context = new VRMImporterContext(vrmData))
                {
                    RuntimeGltfInstance loaded = context.Load();

                    loaded.ShowMeshes();

                    _GltfInstanceDisposer = loaded;
                }
            }
            else
            {
                Debug.LogWarningFormat("File is not found. {0}", _LocalFilePath);
            }
        }

        private void OnDestroy()
        {
            _GltfInstanceDisposer?.Dispose();
        }
    }
}
