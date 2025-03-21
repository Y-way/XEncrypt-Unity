using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEditor;
using UnityEngine;

public class Test
{
    const string s_source = "Assets/Sample/test.txt";
    const string s_xfile = "Assets/Sample/test.x";

    [MenuItem("XEncrypt/加密")]
    static void Encrypt()
    {
        if (!File.Exists(s_source))
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("This is a test.");
            sb.AppendLine("This is a test.");
            sb.AppendLine("This is a test.");
            sb.AppendLine("This is a test.");
            File.WriteAllText(s_source, sb.ToString());
        }

        XFileEncoder.Generator.Encrypt(s_source, s_xfile, 32, XEncryptAPI.XEFPlugin.XEncodeType.XGZip);

        AssetDatabase.Refresh();
    }

    [MenuItem("XEncrypt/解密")]
    static void Decrypt()
    {
        XFileEncoder.Generator.Decrypt(s_xfile, s_source);
        AssetDatabase.Refresh();
    }
}
