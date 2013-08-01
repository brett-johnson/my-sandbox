using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace proto9901
{
  class CloudQueueTools
  {
    public struct IdentityResult
    {
      public string token;
      public string tenant;
      public DateTime expires;
      public string reply;
    }

    public struct ConnectionSettings
    {
      public string token;
      public string tenant;
      public string url;
      public string q;
    }

    static public void DisableCertChecking()
    {
      ServicePointManager.ServerCertificateValidationCallback =
       new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
    }

    public static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
    {
      return true;
    }

    static public IdentityResult AuthenticateIdentity(string url, string userName, string apiKey)
    {
      IdentityResult result = new IdentityResult();

      // this is what we are sending
      string post_data = "{ \"auth\":{ \"RAX-KSKEY:apiKeyCredentials\":{ \"username\":\"YYYYYYYYYYYY\", \"apiKey\":\"XXXXXXXXXXXX\" } } }";
      post_data = post_data.Replace("YYYYYYYYYYYY", userName);
      post_data = post_data.Replace("XXXXXXXXXXXX", apiKey);

      // this is where we will send it

      // create a request
      HttpWebRequest request = (HttpWebRequest)
      WebRequest.Create(url); request.KeepAlive = false;
      request.ProtocolVersion = HttpVersion.Version10;
      request.Method = "POST";

      // turn our request string into a byte stream
      byte[] postBytes = Encoding.ASCII.GetBytes(post_data);

      try
      {
        // this is important - make sure you specify type this way
        request.ContentType = "application/json";
        request.ContentLength = postBytes.Length;
        Stream requestStream = request.GetRequestStream();

        // now send it
        requestStream.Write(postBytes, 0, postBytes.Length);
        requestStream.Close();

        // grab the response and print it out to the console along with the status code
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        result.reply = new StreamReader(response.GetResponseStream()).ReadToEnd();

        // parse out the token ID and tenant ID
        string tokentext = "\"token\":{\"id\":\"";
        result.token = GetJsonValue(tokentext, result.reply, 32);
        string tenanttext = "\"tenant\":{\"id\":\"";
        result.tenant = GetJsonValue(tenanttext, result.reply, 7);
        string expirestext = "\"expires\":\"";
        string expiresat = GetJsonValue(expirestext, result.reply, 19);
        result.expires = DateTime.Parse(expiresat);

        return result;
      }
      catch (System.Net.WebException e)
      {
        MessageBox.Show(e.ToString(), "Authentication Failure", MessageBoxButtons.OK);
      }

      result.token = result.tenant = "";
      return result;
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

    static public string InsertMessageIntoQueue(ConnectionSettings connection, string message)
    {
      string reply = "";
      connection.url = connection.url.Replace("QQQQQQQQQQ", connection.q);

      // create a request
      HttpWebRequest request = (HttpWebRequest)
      WebRequest.Create(connection.url); request.KeepAlive = false;
      request.ProtocolVersion = HttpVersion.Version10;
      request.Method = "POST";

      // turn our request string into a byte stream
      byte[] postBytes = Encoding.ASCII.GetBytes(message);

      try
      {
        // this is important - make sure you specify type this way
        request.Headers.Add("X-Auth-Token", connection.token);
        request.Headers.Add("Client-ID", "InjectionClient");
        request.Headers.Add("X-Project-Id", connection.tenant);
        request.ContentType = "application/json";
        request.ContentLength = postBytes.Length;
        Stream requestStream = request.GetRequestStream();

        // now send it
        requestStream.Write(postBytes, 0, postBytes.Length);
        requestStream.Close();

        // grab the response and print it out to the console along with the status code
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        reply = new StreamReader(response.GetResponseStream()).ReadToEnd();
      }
      catch (System.Net.WebException e)
      {
        MessageBox.Show(e.ToString(), "CloudQueue Insert Failure", MessageBoxButtons.OK);
      }

      return reply;
    }
  }
}
