
﻿using System.Configuration;
using System.Data;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace TO_DO
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private static readonly string ConfigPath = Path.Combine(Directory.GetCurrentDirectory(),"todo.json");
        //public static List<ToDoItem> LoadConfig()
        //{
        //    if (File.Exists(ConfigPath))
        //    {
        //        var json = File.ReadAllText(ConfigPath);
        //        return JsonSerializer.Deserialize<List<ToDoItem>>(json) ?? new List<ToDoItem>();
        //    }
        //    return new List<ToDoItem>();
        //}
        //public static void SaveConfig(List<ToDoItem> config)
        //{
        //    var json = JsonSerializer.Serialize(config, new JsonSerializerOptions { WriteIndented = true });
        //    File.WriteAllText(ConfigPath, json);
        //}
    }

}
