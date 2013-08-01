// csharphttps1: sends an auth request to identity server
//
// NOTE: YOU MUST ENTER A VALID API KEY FOR THIS TO WORK
//
// The following code returns a result like this:
// {"access":{"token":{"id":"f9a5b7d7756e4af3b4d70ce1fae5032c","expires":"2013-06-28T05:59:25.864-05:00","tenant":{"id":"5701876","name":"5701876"}},"serviceCatalog":[{"name":"cloudFilesCDN","endpoints":[{"region":"ORD","tenantId":"MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4","publicURL":"https:\/\/cdn2.clouddrive.com\/v1\/MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4"},{"region":"DFW","tenantId":"MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4","publicURL":"https:\/\/cdn1.clouddrive.com\/v1\/MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4"},{"region":"SYD","tenantId":"MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4","publicURL":"https:\/\/cdn4.clouddrive.com\/v1\/MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4"}],"type":"rax:object-cdn"},{"name":"cloudFiles","endpoints":[{"region":"ORD","tenantId":"MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4","publicURL":"https:\/\/storage101.ord1.clouddrive.com\/v1\/MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4","internalURL":"https:\/\/snet-storage101.ord1.clouddrive.com\/v1\/MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4"},{"region":"DFW","tenantId":"MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4","publicURL":"https:\/\/storage101.dfw1.clouddrive.com\/v1\/MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4","internalURL":"https:\/\/snet-storage101.dfw1.clouddrive.com\/v1\/MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4"},{"region":"SYD","tenantId":"MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4","publicURL":"https:\/\/storage101.syd2.clouddrive.com\/v1\/MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4","internalURL":"https:\/\/snet-storage101.syd2.clouddrive.com\/v1\/MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4"}],"type":"object-store"},{"name":"cloudDatabases","endpoints":[{"region":"SYD","tenantId":"5701876","publicURL":"https:\/\/syd.databases.api.rackspacecloud.com\/v1.0\/5701876"},{"region":"DFW","tenantId":"5701876","publicURL":"https:\/\/dfw.databases.api.rackspacecloud.com\/v1.0\/5701876"},{"region":"ORD","tenantId":"5701876","publicURL":"https:\/\/ord.databases.api.rackspacecloud.com\/v1.0\/5701876"}],"type":"rax:database"},{"name":"cloudBlockStorage","endpoints":[{"region":"SYD","tenantId":"5701876","publicURL":"https:\/\/syd.blockstorage.api.rackspacecloud.com\/v1\/5701876"},{"region":"DFW","tenantId":"5701876","publicURL":"https:\/\/dfw.blockstorage.api.rackspacecloud.com\/v1\/5701876"},{"region":"ORD","tenantId":"5701876","publicURL":"https:\/\/ord.blockstorage.api.rackspacecloud.com\/v1\/5701876"}],"type":"volume"},{"name":"cloudServersOpenStack","endpoints":[{"region":"SYD","tenantId":"5701876","publicURL":"https:\/\/syd.servers.api.rackspacecloud.com\/v2\/5701876","versionInfo":"https:\/\/syd.servers.api.rackspacecloud.com\/v2","versionList":"https:\/\/syd.servers.api.rackspacecloud.com\/","versionId":"2"},{"region":"DFW","tenantId":"5701876","publicURL":"https:\/\/dfw.servers.api.rackspacecloud.com\/v2\/5701876","versionInfo":"https:\/\/dfw.servers.api.rackspacecloud.com\/v2","versionList":"https:\/\/dfw.servers.api.rackspacecloud.com\/","versionId":"2"},{"region":"ORD","tenantId":"5701876","publicURL":"https:\/\/ord.servers.api.rackspacecloud.com\/v2\/5701876","versionInfo":"https:\/\/ord.servers.api.rackspacecloud.com\/v2","versionList":"https:\/\/ord.servers.api.rackspacecloud.com\/","versionId":"2"}],"type":"compute"},{"name":"cloudLoadBalancers","endpoints":[{"region":"SYD","tenantId":"5701876","publicURL":"https:\/\/syd.loadbalancers.api.rackspacecloud.com\/v1.0\/5701876"},{"region":"ORD","tenantId":"5701876","publicURL":"https:\/\/ord.loadbalancers.api.rackspacecloud.com\/v1.0\/5701876"},{"region":"DFW","tenantId":"5701876","publicURL":"https:\/\/dfw.loadbalancers.api.rackspacecloud.com\/v1.0\/5701876"}],"type":"rax:load-balancer"},{"name":"cloudDNS","endpoints":[{"tenantId":"5701876","publicURL":"https:\/\/dns.api.rackspacecloud.com\/v1.0\/5701876"}],"type":"rax:dns"},{"name":"cloudMonitoring","endpoints":[{"tenantId":"5701876","publicURL":"https:\/\/monitoring.api.rackspacecloud.com\/v1.0\/5701876"}],"type":"rax:monitor"},{"name":"cloudBackup","endpoints":[{"tenantId":"5701876","publicURL":"https:\/\/backup.api.rackspacecloud.com\/v1.0\/5701876"}],"type":"rax:backup"},{"name":"cloudServers","endpoints":[{"tenantId":"5701876","publicURL":"https:\/\/servers.api.rackspacecloud.com\/v1.0\/5701876","versionInfo":"https:\/\/servers.api.rackspacecloud.com\/v1.0","versionList":"https:\/\/servers.api.rackspacecloud.com\/","versionId":"1.0"}],"type":"compute"}],"user":{"id":"114677","roles":[{"tenantId":"MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4","id":"5","description":"A Role that allows a user access to keystone Service methods","name":"object-store:default"},{"tenantId":"5701876","id":"6","description":"A Role that allows a user access to keystone Service methods","name":"compute:default"},{"id":"3","description":"User Admin Role.","name":"identity:user-admin"}],"name":"usquattro1","RAX-AUTH:defaultRegion":"ORD"}}}
// OK
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace proto9903
{
  class Program
  {
    static void Main(string[] args)
    {
      System.Console.Write("ENTER API KEY FOR usquattro1: ");
      string apikey = System.Console.ReadLine();

      // this is what we are sending
      string post_data = "{ \"auth\":{ \"RAX-KSKEY:apiKeyCredentials\":{ \"username\":\"usquattro1\", \"apiKey\":\"XXXXXXXXXXXX\" } } }";
      post_data = post_data.Replace("XXXXXXXXXXXX", apikey);

      // this is where we will send it
      string uri = "https://identity.api.rackspacecloud.com/v2.0/tokens/";

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
        request.ContentType = "application/json";
        request.ContentLength = postBytes.Length;
        Stream requestStream = request.GetRequestStream();

        // now send it
        requestStream.Write(postBytes, 0, postBytes.Length);
        requestStream.Close();

        // grab te response and print it out to the console along with the status code
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
