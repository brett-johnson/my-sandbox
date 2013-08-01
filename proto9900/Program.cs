// override certificate validation!!!!!!!

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace proto9900
{
  class Program
  {
    public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
    {
      return true;
    }

    static void Main(string[] args)
    {
      ServicePointManager.ServerCertificateValidationCallback =
        new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
      System.Console.Write("ENTER TOKEN FOR usquattro1: ");
      string token = System.Console.ReadLine();

      // this is what we are sending
      string post_data = "[{\"ttl\": 5500,\"body\": {\"myEvent\": \"myBackupStarted\"}}, {\"ttl\": 600,\"body\": {\"myValue\": \"DATA associated with myValue\"}}]";
      // this is where we will send it
      string uri = "https://preview.queue.api.rackspacecloud.com:443/v1/queues/mysamplequeue/messages";

      // create a request
      HttpWebRequest request = (HttpWebRequest)
      WebRequest.Create(uri); request.KeepAlive = false;
      request.ProtocolVersion = HttpVersion.Version10;
      request.Method = "POST";

      // turn our request string into a byte stream
      byte[] postBytes = Encoding.ASCII.GetBytes(post_data);

      try
      {
        // this is important - make sure you specify type this way
        request.Headers.Add("X-Auth-Token", token);
        request.Headers.Add("Client-ID", "MyClient");
        request.Headers.Add("X-Project-Id", "5701876");
        request.ContentType = "application/json";
        request.ContentLength = postBytes.Length;
        Stream requestStream = request.GetRequestStream();

        // now send it
        requestStream.Write(postBytes, 0, postBytes.Length);
        requestStream.Close();

        // grab the response and print it out to the console along with the status code
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        string result = new StreamReader(response.GetResponseStream()).ReadToEnd();
        Console.WriteLine(result);
        Console.WriteLine(response.StatusCode);

        // parse out the token ID and tenant ID
        string tokentext = "\"token\":{\"id\":\"";
        string tokenid = GetJsonValue(tokentext, result, 32);
        System.Console.WriteLine("TOKEN ID: " + tokenid);
        string tenanttext = "\"tenant\":{\"id\":\"";
        string tenantid = GetJsonValue(tenanttext, result, 7);
        System.Console.WriteLine("TENANT ID: " + tenantid);
      }
      catch (System.Net.WebException e)
      {
        Console.WriteLine(e.ToString());
      }
    }

    static public string GetJsonValue(string key, string src, int len)
    {
      int x = src.IndexOf(key);
      if (0 > x)
      {
        return "";
      }
      string value = src.Substring(x + key.Length, len);
      return value;
    }
  }
}
