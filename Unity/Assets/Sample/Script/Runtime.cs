using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Runtime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        byte[] encryptedData = null;
        byte[] decryptedData = null;
        using (XEncryptAPI.EncryptScope scope = new XEncryptAPI.EncryptScope(XEncryptAPI.XEFPlugin.XEncodeType.XGZip, 32))
        {
            string data = "This is a test string.";
            byte[] rawdata = System.Text.Encoding.UTF8.GetBytes(data);

            scope.Begin();
            XEncryptAPI.ResultCode result = scope.EncryptData(rawdata, out encryptedData);
            scope.End();
            Debug.LogWarning($"Encrypt {result}");

            Debug.LogWarning($"Encrypted Data:{System.Text.Encoding.UTF8.GetString(encryptedData)}");
        }

        using (XEncryptAPI.DecryptScope scope = new XEncryptAPI.DecryptScope())
        {
            scope.Begin();
            XEncryptAPI.ResultCode result = scope.DecryptData(encryptedData, out decryptedData);
            scope.End();
            Debug.LogWarning($"Decrypt {result}");

            Debug.LogWarning($"Decrypted Data:{System.Text.Encoding.UTF8.GetString(decryptedData)}");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
