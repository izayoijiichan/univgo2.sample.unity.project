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
                var gltfParser = new GltfParser();

                gltfParser.ParsePath(_LocalFilePath);

                var vrmImporterContext = new VRMImporterContext(gltfParser);

                vrmImporterContext.Load();

                vrmImporterContext.EnableUpdateWhenOffscreen();

                vrmImporterContext.ShowMeshes();
            }
            else
            {
                Debug.LogWarningFormat("File is not found. {0}", _LocalFilePath);
            }
        }
    }
}
