using UnityEngine;
using System.Collections;

/// <summary>
/// 负责监视资源工厂
/// 工厂将资源加载完毕后所需要进行的行为
/// </summary>
public abstract class  ObserveFactory
{
    //public System.Action loaddoneAction { get; set; }

	/// <summary>
	/// Receivems the message from sunject.
	/// 观察行为
	/// </summary>
    public abstract void ObserveAction();
}
