using UnityEngine;
using System.Collections;

public class VideoFactory : AssetsFactory 
{
     public VideoFactory(string type):base(type)
    {

    }

    public override DownLoadDevice CreateDownloadDevice()
    {
        VideoDLDevice result = GameObject.FindObjectOfType<VideoDLDevice>();

        if (result == null)
        {
            result = new GameObject("VideoDLDevice").AddComponent<VideoDLDevice>();
        }

        return result;
    }

    public override void LoadAssets(string fullPath)
    {
        base.LoadAssets(fullPath);

        //NotifyObserver();
    }
}
