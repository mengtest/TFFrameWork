﻿using System.IO;
using UnityEngine;

namespace TJ
{
    /// <summary>
    /// AB 打包及运行时路径解决器
    /// </summary>
    public class AssetBundlePathResolver
    {
        public static AssetBundlePathResolver instance;

        public AssetBundlePathResolver()
        {
            instance = this;
        }


        /// <summary>
        /// AB 保存的路径相对于 Assets/StreamingAssets 的名字
        /// </summary>
        public virtual string BundleSaveDirName { get { return "assetbundles"; } }

#if UNITY_EDITOR
        /// <summary>
        /// AB 保存的路径
        /// </summary>
        public string BundleSavePath { get { return "Assets/StreamingAssets/" + BundleSaveDirName; } }
        /// <summary>
        /// 在编辑器模型下将 abName 转为 Assets/... 路径
        /// 这样就可以不用打包直接用了
        /// </summary>
        /// <param name="abName"></param>
        /// <returns></returns>
        public virtual string GetEditorModePath(string abName)
        {
            //将 Assets.AA.BB.prefab 转为 Assets/AA/BB.prefab
            abName = abName.Replace(".", "/");
            int last = abName.LastIndexOf("/");

            if (last == -1)
                return abName;

            string path = string.Format("{0}.{1}", abName.Substring(0, last), abName.Substring(last + 1));
            return path;
        }
#endif

//        /// <summary>
//        /// 获取 AB 源文件路径（打包进安装包的）
//        /// </summary>
//        /// <param name="path"></param>
//        /// <param name="forWWW"></param>
//        /// <returns></returns>
//        public virtual string GetBundleSourceFile(string path, bool forWWW = true)
//        {
//            string filePath = null;
//#if UNITY_EDITOR
//            if (forWWW)
//                filePath = string.Format("file://{0}/StreamingAssets/{1}/{2}", Application.dataPath, BundleSaveDirName, path);
//            else
//                filePath = string.Format("{0}/StreamingAssets/{1}/{2}", Application.dataPath, BundleSaveDirName, path);
//#elif UNITY_ANDROID
//            if (forWWW)
//                filePath = string.Format("jar:file://{0}!/assets/{1}/{2}", Application.dataPath, BundleSaveDirName, path);
//            else
//                filePath = string.Format("{0}!assets/{1}/{2}", Application.dataPath, BundleSaveDirName, path);
//#elif UNITY_IOS
//            if (forWWW)
//                filePath = string.Format("file://{0}/Raw/{1}/{2}", Application.dataPath, BundleSaveDirName, path);
//            else
//                filePath = string.Format("{0}/Raw/{1}/{2}", Application.dataPath, BundleSaveDirName, path);
//#else
//            throw new System.NotImplementedException();
//#endif
//            return filePath;
//        }


        public virtual string AssetBundleFileList { get { return "assetlist.txt"; } }

    }
}