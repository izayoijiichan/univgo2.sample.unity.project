namespace UniVgoDemos
{
    using System.IO;
    using UniGLTF;
    using UnityEngine;
    using VRM;

    public class RuntimeLoadVrmBehaviour : MonoBehaviour
    {
        [SerializeField]
        private string _LocalFilePath = null;

        private void Start()
        {
            if (File.Exists(_LocalFilePath))
            {
                var parser = new GlbFileParser(_LocalFilePath);

                GltfData data = parser.Parse();

                using (var context = new VRMImporterContext(data))
                {
                    RuntimeGltfInstance loaded = context.Load();

                    loaded.EnableUpdateWhenOffscreen();

                    loaded.ShowMeshes();
                }
            }
            else
            {
                Debug.LogWarningFormat("File is not found. {0}", _LocalFilePath);
            }
        }
    }
}
