using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileFactroyObserve : ObserveFactory 
{
    public override void ObserveAction()
    {
        Debug.Log("文件资源加载完毕了,可以开始后续工作了....");
    }
}
