using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class BytesExtension
{
    /// <summary>
    /// btye轉單位
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string FormatBytes(long bytes)
    {
        string[] Suffix = { "B", "KB", "MB", "GB", "TB" };
        int i;
        double dblSByte = bytes;
        for (i = 0; i < Suffix.Length && bytes >= 1024; i++, bytes /= 1024)
        {
            dblSByte = bytes / 1024.0;
        }
        return $"{dblSByte.ToString("0")}{Suffix[i]}";
    }

}