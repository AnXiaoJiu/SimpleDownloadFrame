using UnityEngine;
using System.Collections;

public class ModelDLDevice : DownLoadDevice 
{
    public override void DownLoadFileFromServer(string fromUrl, string folderPath, string fileName)
    {
        base.DownLoadFileFromServer(fromUrl, folderPath, fileName);
    }

}
