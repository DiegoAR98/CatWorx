using System;
using System.IO;
using System.Collections.Generic;
using System.Net.Http;
using SkiaSharp;

namespace CatWorx.BadgeMaker
{
  class Util
  {
    // Add List parameter to method
    public static void PrintEmployees(List<Employee> employees) 
    {
      for (int i = 0; i < employees.Count; i++) 
      {
        string template = "{0,-10}\t{1,-20}\t{2}";
        Console.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
      }
    }
    public static void MakeCSV(List<Employee> employees)
    {
        // Check to see if folder exists
if (!Directory.Exists("data")) 
{
  // If not, create it
  Directory.CreateDirectory("data");
}
using (StreamWriter file = new StreamWriter("data/employees.csv"))
{
  file.WriteLine("ID,Name,PhotoUrl");

  // Loop over employees
  for (int i = 0; i < employees.Count; i++)
  {
    // Write each employee to the file
    string template = "{0},{1},{2}";
    file.WriteLine(String.Format(template, employees[i].GetId(), employees[i].GetFullName(), employees[i].GetPhotoUrl()));
  }
}
   }
public static void MakeBadges(List<Employee> employees)
{
  // instance of HttpClient is disposed after code in the block has run
  using(HttpClient client = new HttpClient())
  {
for (int i = 0; i < employees.Count; i++)
  {
  }
  }
}
  }
}