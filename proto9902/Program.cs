using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace proto9902
{
  class Program
  {
    static void Main(string[] args)
    {
      string[] lines = System.IO.File.ReadAllLines(@"E:\dev\prototypes\proto9907\Program.cs");
      System.Console.Write(lines[0] + lines[1] + lines[2]);
    }
  }
}
