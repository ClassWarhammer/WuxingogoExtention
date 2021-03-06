using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using wuxingogo.Code;

namespace CreateAssets
{
    public class CreateXBaseWindow : CreateUnityScript
    {
        [MenuItem("Assets/Create/Wuxingogo/XBaseWindow", false, 100)]
        public static void CreateBaseWindow()
        {
            string path = GetPath("Create Window Class", "NewBaseWindow.cs");
            if (path == "")
                return;
            string dictionary = path.Substring(0, path.LastIndexOf('/'));


            string[] strArray = path.Split('/');
            string suffix = strArray[strArray.Length - 1];
            int suffixIndex = suffix.IndexOf('.');
            string fileName = suffix.Substring(0, suffixIndex);
            path = FileUtil.GetProjectRelativePath(path);

            string assetPath = XEditorSetting.TemplatesPath + "/" + "NewXBaseWindow.asset";
            assetPath = FileUtil.GetProjectRelativePath(assetPath);
            XCodeObject co = AssetDatabase.LoadAssetAtPath<XCodeObject>(assetPath);
            co.className = fileName;
            co.Compile(dictionary + "/" + suffix);


        }

    }
}