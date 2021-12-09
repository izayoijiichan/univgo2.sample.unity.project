namespace UniVgoDemos
{
    using System.IO;
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
                var vrmImporterContext = new VRMImporterContext();

                vrmImporterContext.Load(_LocalFilePath);

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
