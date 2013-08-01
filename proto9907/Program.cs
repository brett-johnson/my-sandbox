using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace proto9907
{
  class Program
  {
    static void Main(string[] args)
    {
      string s = "{\"access\":{\"token\":{\"id\":\"f9a5b7d7756e4af3b4d70ce1fae5032c\",\"expires\":\"2013-06-28T05:59:25.864-05:00\",\"tenant\":{\"id\":\"5701876\",\"name\":\"5701876\"}},\"serviceCatalog\":[{\"name\":\"cloudFilesCDN\",\"endpoints\":[{\"region\":\"ORD\",\"tenantId\":\"MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4\",\"publicURL\":\"https:\\/\\/cdn2.clouddrive.com\\/v1\\/MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4\"},{\"region\":\"DFW\",\"tenantId\":\"MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4\",\"publicURL\":\"https:\\/\\/cdn1.clouddrive.com\\/v1\\/MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4\"},{\"region\":\"SYD\",\"tenantId\":\"MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4\",\"publicURL\":\"https:\\/\\/cdn4.clouddrive.com\\/v1\\/MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4\"}],\"type\":\"rax:object-cdn\"},{\"name\":\"cloudFiles\",\"endpoints\":[{\"region\":\"ORD\",\"tenantId\":\"MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4\",\"publicURL\":\"https:\\/\\/storage101.ord1.clouddrive.com\\/v1\\/MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4\",\"internalURL\":\"https:\\/\\/snet-storage101.ord1.clouddrive.com\\/v1\\/MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4\"},{\"region\":\"DFW\",\"tenantId\":\"MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4\",\"publicURL\":\"https:\\/\\/storage101.dfw1.clouddrive.com\\/v1\\/MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4\",\"internalURL\":\"https:\\/\\/snet-storage101.dfw1.clouddrive.com\\/v1\\/MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4\"},{\"region\":\"SYD\",\"tenantId\":\"MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4\",\"publicURL\":\"https:\\/\\/storage101.syd2.clouddrive.com\\/v1\\/MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4\",\"internalURL\":\"https:\\/\\/snet-storage101.syd2.clouddrive.com\\/v1\\/MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4\"}],\"type\":\"object-store\"},{\"name\":\"cloudDatabases\",\"endpoints\":[{\"region\":\"SYD\",\"tenantId\":\"5701876\",\"publicURL\":\"https:\\/\\/syd.databases.api.rackspacecloud.com\\/v1.0\\/5701876\"},{\"region\":\"DFW\",\"tenantId\":\"5701876\",\"publicURL\":\"https:\\/\\/dfw.databases.api.rackspacecloud.com\\/v1.0\\/5701876\"},{\"region\":\"ORD\",\"tenantId\":\"5701876\",\"publicURL\":\"https:\\/\\/ord.databases.api.rackspacecloud.com\\/v1.0\\/5701876\"}],\"type\":\"rax:database\"},{\"name\":\"cloudBlockStorage\",\"endpoints\":[{\"region\":\"SYD\",\"tenantId\":\"5701876\",\"publicURL\":\"https:\\/\\/syd.blockstorage.api.rackspacecloud.com\\/v1\\/5701876\"},{\"region\":\"DFW\",\"tenantId\":\"5701876\",\"publicURL\":\"https:\\/\\/dfw.blockstorage.api.rackspacecloud.com\\/v1\\/5701876\"},{\"region\":\"ORD\",\"tenantId\":\"5701876\",\"publicURL\":\"https:\\/\\/ord.blockstorage.api.rackspacecloud.com\\/v1\\/5701876\"}],\"type\":\"volume\"},{\"name\":\"cloudServersOpenStack\",\"endpoints\":[{\"region\":\"SYD\",\"tenantId\":\"5701876\",\"publicURL\":\"https:\\/\\/syd.servers.api.rackspacecloud.com\\/v2\\/5701876\",\"versionInfo\":\"https:\\/\\/syd.servers.api.rackspacecloud.com\\/v2\",\"versionList\":\"https:\\/\\/syd.servers.api.rackspacecloud.com\\/\",\"versionId\":\"2\"},{\"region\":\"DFW\",\"tenantId\":\"5701876\",\"publicURL\":\"https:\\/\\/dfw.servers.api.rackspacecloud.com\\/v2\\/5701876\",\"versionInfo\":\"https:\\/\\/dfw.servers.api.rackspacecloud.com\\/v2\",\"versionList\":\"https:\\/\\/dfw.servers.api.rackspacecloud.com\\/\",\"versionId\":\"2\"},{\"region\":\"ORD\",\"tenantId\":\"5701876\",\"publicURL\":\"https:\\/\\/ord.servers.api.rackspacecloud.com\\/v2\\/5701876\",\"versionInfo\":\"https:\\/\\/ord.servers.api.rackspacecloud.com\\/v2\",\"versionList\":\"https:\\/\\/ord.servers.api.rackspacecloud.com\\/\",\"versionId\":\"2\"}],\"type\":\"compute\"},{\"name\":\"cloudLoadBalancers\",\"endpoints\":[{\"region\":\"SYD\",\"tenantId\":\"5701876\",\"publicURL\":\"https:\\/\\/syd.loadbalancers.api.rackspacecloud.com\\/v1.0\\/5701876\"},{\"region\":\"ORD\",\"tenantId\":\"5701876\",\"publicURL\":\"https:\\/\\/ord.loadbalancers.api.rackspacecloud.com\\/v1.0\\/5701876\"},{\"region\":\"DFW\",\"tenantId\":\"5701876\",\"publicURL\":\"https:\\/\\/dfw.loadbalancers.api.rackspacecloud.com\\/v1.0\\/5701876\"}],\"type\":\"rax:load-balancer\"},{\"name\":\"cloudDNS\",\"endpoints\":[{\"tenantId\":\"5701876\",\"publicURL\":\"https:\\/\\/dns.api.rackspacecloud.com\\/v1.0\\/5701876\"}],\"type\":\"rax:dns\"},{\"name\":\"cloudMonitoring\",\"endpoints\":[{\"tenantId\":\"5701876\",\"publicURL\":\"https:\\/\\/monitoring.api.rackspacecloud.com\\/v1.0\\/5701876\"}],\"type\":\"rax:monitor\"},{\"name\":\"cloudBackup\",\"endpoints\":[{\"tenantId\":\"5701876\",\"publicURL\":\"https:\\/\\/backup.api.rackspacecloud.com\\/v1.0\\/5701876\"}],\"type\":\"rax:backup\"},{\"name\":\"cloudServers\",\"endpoints\":[{\"tenantId\":\"5701876\",\"publicURL\":\"https:\\/\\/servers.api.rackspacecloud.com\\/v1.0\\/5701876\",\"versionInfo\":\"https:\\/\\/servers.api.rackspacecloud.com\\/v1.0\",\"versionList\":\"https:\\/\\/servers.api.rackspacecloud.com\\/\",\"versionId\":\"1.0\"}],\"type\":\"compute\"}],\"user\":{\"id\":\"114677\",\"roles\":[{\"tenantId\":\"MossoCloudFS_314107bf-2042-4c9c-b4e9-4696a183c1e4\",\"id\":\"5\",\"description\":\"A Role that allows a user access to keystone Service methods\",\"name\":\"object-store:default\"},{\"tenantId\":\"5701876\",\"id\":\"6\",\"description\":\"A Role that allows a user access to keystone Service methods\",\"name\":\"compute:default\"},{\"id\":\"3\",\"description\":\"User Admin Role.\",\"name\":\"identity:user-admin\"}],\"name\":\"usquattro1\",\"RAX-AUTH:defaultRegion\":\"ORD\"}}}\nOK";
      string tokentext = "\"token\":{\"id\":\"";
      //int tokenX = s.IndexOf(tokentext);
      //string tokenid = s.Substring(tokenX + tokentext.Length, 32);
      string tokenid = Get(tokentext, s, 32);
      System.Console.WriteLine("TOKEN ID: " + tokenid);
      string tenanttext = "\"tenant\":{\"id\":\"";
      string tenantid = Get(tenanttext, s, 7);
      System.Console.WriteLine("TENANT ID: " + tenantid);
    }

    static public string Get(string key, string src, int len)
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
