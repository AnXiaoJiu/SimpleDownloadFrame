using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class FilesFactory : AssetsFactory 
{
    public FilesFactory(string type) 
        :base(type)
    {

    }

    public override DownLoadDevice CreateDownloadDevice()
    {
        FileDLDevice result = GameObject.FindObjectOfType<FileDLDevice>();

        if (result == null)
       {
          result = new GameObject("FileDLDevice").AddComponent<FileDLDevice>();
       }

        return result;
    }


    public override void LoadAssets(string fullPath)
    {
        base.LoadAssets(fullPath);

//         if (loadAssetDelegate != null)
//         {
//             loadAssetDelegate(fullPath);
//         }

         NotifyObserver();
    }
}
