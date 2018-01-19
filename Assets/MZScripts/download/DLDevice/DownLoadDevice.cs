using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using System.IO;

/// <summary>
/// 下载器(被观察者)
/// 工厂(观察者)
/// 下载器完成下载之后通知所有观察者下载完毕
/// 另外:提供下载所需要显示的UI
/// </summary>
public class DownLoadDevice : MonoBehaviour 
{
    public Action<WWW> downloading {get;set;}

	private AssetsFactory observer = null;

	/// <summary>
	/// Adds the observer.
	/// </summary>
	public void AddObserver(AssetsFactory ob)
	{
        observer = ob;
	}

    public virtual void DownLoadFileFromServer(string fromUrl, string folderPath, string fileName)
    {
        StartCoroutine(FileHelper.Instance.DownLoadFile(fromUrl, folderPath, fileName, DownloadProgress, NotifyObserver));
    }


	/// <summary>
	/// 发送消息给观察者们
	/// 观察者需要有响应的方法
	/// </summary>
	public void NotifyObserver(string fullPath)
	{
        //MyHelper.Instance.MyDebugLog(Path.GetFileName(fullPath) + "--下载完毕");
        
        if (observer == null) return;

        observer.LoadAssets(fullPath);

        observer = null;     //移除下载器的监听
	}

    private void DownloadProgress(WWW www)
    {
        if (downloading != null)
        {
            downloading(www);
        }
    }
}
