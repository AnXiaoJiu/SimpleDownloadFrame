using UnityEngine;
using System.Collections;

public class VideoDLDevice : DownLoadDevice 
{
    public override void DownLoadFileFromServer(string fromUrl, string folderPath, string fileName)
    {
        base.DownLoadFileFromServer(fromUrl, folderPath, fileName);
    }
}
