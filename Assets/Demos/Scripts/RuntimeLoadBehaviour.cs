namespace UniVgoDemos
{
    using System.IO;
    using UnityEngine;
    using UniVgo2;

    public class RuntimeLoadBehaviour : MonoBehaviour
    {
        [SerializeField]
        private string _LocalFilePath = null;

        private void Start()
        {
            if (File.Exists(_LocalFilePath))
            {
                var vgoImporter = new VgoImporter();

                vgoImporter.Load(_LocalFilePath);

                vgoImporter.ReflectSkybox(Camera.main);
            }
            else
            {
                Debug.LogWarningFormat("File is not found. {0}", _LocalFilePath);
            }
        }
    }
}
