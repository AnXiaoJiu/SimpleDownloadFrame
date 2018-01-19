using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// 抽象工厂
/// 工厂负责创建下载器
/// 下载器负责下载资源
/// 资源下载完毕后再由工厂加载
/// </summary>
public abstract class AssetsFactory
{
    //资源加载代理
   // public Action<string> loadAssetDelegate { get; set; }

    public AssetsFactory(string type)
    {
        this.type = type;
    }

    protected string type {get;set;}  //资源类型

    /// <summary>
    /// 创建下载器
    /// </summary>
    /// <returns></returns>
    public abstract DownLoadDevice CreateDownloadDevice();

    /// <summary>
	///  Receives the message from subject.
    /// 加载资源
    /// </summary>
    /// <param name="fullPath"></param>
    public virtual void LoadAssets(string fullPath)
    {
        Debug.Log("开始加载资源,资源路径是:" + fullPath);
    }

	/// <summary>
	/// The observes.
	/// 工厂观察者列表
	/// </summary>
	private List<ObserveFactory> observes = new List<ObserveFactory> ();


	public void AddObserve(ObserveFactory ob)
	{
		observes.Add (ob);
	}


	/// <summary>
    ///通知观察者：
	///比如:资源加载完毕通知观察者
	/// </summary>
    protected void NotifyObserver()
	{
		foreach (ObserveFactory ob in observes) {
                ob.ObserveAction();
		}
        observes.Clear();
	}

}
