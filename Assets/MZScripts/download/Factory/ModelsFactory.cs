using UnityEngine;
using System.Collections;

public class ModelsFactory : AssetsFactory
{

    public ModelsFactory(string type)
        : base(type)
    {
        
    }


    public override DownLoadDevice CreateDownloadDevice()
    {

        ModelDLDevice result = GameObject.FindObjectOfType<ModelDLDevice>();

        if (result == null)
        {
            result = new GameObject("ModelDLDevice").AddComponent<ModelDLDevice>();
        }

        return result;
    }

    public override void LoadAssets(string fullPath)
    {
        base.LoadAssets(fullPath);

        // base.NotifyObserver();
    }

}
