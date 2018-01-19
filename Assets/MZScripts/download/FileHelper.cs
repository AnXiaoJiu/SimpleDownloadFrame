using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Text;
using System.Net;
using System.Collections.Generic;
using System.Xml;
using System.Security.Cryptography;

public class FileHelper
{

    private static FileHelper _Instance = null;

    public static  FileHelper Instance
    {
        get
        {
            if(_Instance == null)
            {
                _Instance = new FileHelper();
            }

            return _Instance;
        }
    }


    public bool isFileExist(string fullPath)
    {
        bool isExit = File.Exists(fullPath);

        return isExit;
    }




    /// <summary>
    /// 将字节保存为文件 路径当中加入文件的后缀(eg: E:\\zj.txt)
    /// </summary>
    public bool WriteByteToFile(string toPath,byte[] bytes)
    {
        if (isFileExist(toPath))
        {
            File.Delete(toPath);
        }

        using (FileStream fs = new FileStream(toPath, FileMode.OpenOrCreate, FileAccess.Write))
        {
            fs.Write(bytes, 0, bytes.Length);

            if (isFileExist(toPath))
            {
                return true;
            }
            else
            {
                return false;
            }

         
        }
    }


    public void CreateFolder(string folderPath)
    {
        if (!Directory.Exists(folderPath))
        {
            try
            {   
                Directory.CreateDirectory(folderPath);
            }
            catch(Exception ex)
            {
               //MyHelper.Instance.MyDebugLog("创建文件夹失败:"+ ex,MyHelper.MsgType.error);
            }
        }
        else
        {
            return;
        }
    }
    /// <summary>
    /// www 加载服务端文件
    /// </summary>
    /// <param name="fromUrl"></param>
    /// <returns></returns>
    private WWW DownLoadFileFromWeb(string fromUrl)
    {
        WWW www = new WWW(fromUrl);

        return www;    
    }



    /// <summary>
    /// 下载文件
    /// </summary>
    /// <param name="fromUrl"></param>
    /// <param name="folderPath"></param>
    /// <param name="fileName"></param>
    /// <param name="NotifyObserver"></param>
    /// <param name="progress"></param>
    /// <returns></returns>
    public IEnumerator DownLoadFile (
        string fromUrl,
        string folderPath, 
        string fileName, 
        Action<WWW> progress = null, 
        Action<string> NotifyObserver = null)
    {
      using (WWW www = DownLoadFileFromWeb(fromUrl))
      {
          if (www.error != null)
          {
              www.Dispose();         
             // MyHelper.Instance.MyDebugLog("下载失败:" + www.error, MyHelper.MsgType.error);
              yield break;
          }

          while (!www.isDone)
          {
              yield return null;

              if (progress != null) { progress(www); }
          }
          yield return www;

          if (www.isDone && www.error == null)
          {
              byte[] bytes = www.bytes;

              CreateFolder(folderPath);

              string fullPath = folderPath + "/" + fileName;
      
              if (WriteByteToFile(fullPath, bytes))
              {
              
                  if (NotifyObserver != null)
                  {
                      NotifyObserver(fullPath);  //通知下载器的观察者
                  }
              }

              www.Dispose();
          }
      }
       
    }

    


}
