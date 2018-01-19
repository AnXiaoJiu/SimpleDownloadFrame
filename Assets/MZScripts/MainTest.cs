using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTest : MonoBehaviour 
{
    //文件工厂
    AssetsFactory fileFactory = null;
    //下载器
    DownLoadDevice DLDevice = null;
    //工厂观察者
    ObserveFactory observerFactor = null;
	void Start()
    {
        fileFactory = new FilesFactory("文件");
        DLDevice =  fileFactory.CreateDownloadDevice();
        DLDevice.AddObserver(fileFactory);
        observerFactor = new FileFactroyObserve();
        fileFactory.AddObserve(observerFactor);

        string filename = "test.zip";
        string url = "http://127.0.0.1/";
        string curFolder = Application.dataPath;
        string localFolder = curFolder.Substring(0, curFolder.Length - "Assets".Length);

        string server = url + filename;


        DLDevice.DownLoadFileFromServer(server, localFolder, filename);
    }
}
