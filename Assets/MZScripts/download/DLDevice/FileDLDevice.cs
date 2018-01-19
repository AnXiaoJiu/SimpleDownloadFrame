using UnityEngine;
using System.Collections;
using System.IO;

public class FileDLDevice : DownLoadDevice
{
    public override void DownLoadFileFromServer(string fromUrl, string folderPath, string fileName)
    {
        base.DownLoadFileFromServer(fromUrl, folderPath, fileName);
    }
}
