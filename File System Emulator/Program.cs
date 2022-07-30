string path = "root";
DirectoryInfo dirInfo = new DirectoryInfo(path);
if (!dirInfo.Exists)
{
    dirInfo.Create();
}
string command = String.Empty;
while (true)
{
    dirInfo = new DirectoryInfo(path);
    command = Console.ReadLine().ToString();
    string[] commands = command.Split(' ');
        switch (commands[0])
        {
            case "":
                break;
            case "ls":
                if (commands.Length > 1)
                    Console.WriteLine("Command not found");
                Lists();
                break;
            case "pwd":
                if (commands.Length > 1)
                    Console.WriteLine("Command not found");
                FullPath();
                break;
            case "mkdir":
                if (commands.Length !=2)
                    Console.WriteLine("Command not found");
                CreateFolder(commands);
                break;
            case "rm":
                if (commands.Length != 2)
                    Console.WriteLine("Command not found");
                RemoveFile(commands);
                break;
            case "touch":
                if (commands.Length != 2)
                    Console.WriteLine("Command not found");
                CreateFile(commands);
                break;
            case "rmdir":
                if (commands.Length != 2)
                    Console.WriteLine("Command not found");
                RemoveFolder(commands);
                break;
            case "cd":
                if (commands.Length != 2)
                    Console.WriteLine("Command not found");
                AccessesFolder(commands);
                break;
            default:
                Console.WriteLine("Command not found");
                break;
        }
}


void Lists()
{
    if (Directory.Exists(path))
    {
        
        string[] dirs = Directory.GetFileSystemEntries(path);
        for(int i = 0; i < dirs.Length; i++)
        {            
            string[] name = dirs[i].Split(@"\");
                Console.WriteLine(name[name.Length - 1]);
        } 
    }
    else
    {
        Console.WriteLine("Command not found");
    }

}


void CreateFolder(string[] commands)
{
    if (!Directory.Exists(path + @"\" + commands[1]))
    {
        dirInfo.CreateSubdirectory(commands[1]);
    }
    else
    {
        Console.WriteLine("there is already such a file or folder");
    }

}


void CreateFile(string[] commands)
{
    if (!File.Exists(path + @"\" + commands[1]))
    {
        using (FileStream f = File.Create(path + @"\" + commands[1]))
        {
            
            f.Close();
        }
    }
    else
    {
        Console.WriteLine("there is already such a file or folder");
    }
}


void RemoveFolder(string[] commands)
{
    if (Directory.Exists(path + @"\" + commands[1]))
    {
        Directory.Delete(path + @"\" + commands[1]);
    }
    else
    {
        Console.WriteLine("there is no such folder or file");
    }

}


void RemoveFile(string[] commands)
{
    if (File.Exists(path + @"\" + commands[1]))
    {
        File.Delete(path + @"\" + commands[1]);
    }
    else
    {
        Console.WriteLine("there is no such folder or file");
    }
}


void AccessesFolder(string[] commands)
{
    if (commands[1] == "..")
    {
        string[] dirs = path.Split(@"\");
        path = "";
        int i = 0;
        while (true)
        {
            path = path + dirs[i];
            i++;
            if (i >= dirs.Length - 1)
                break;
            path += @"\";
        }
        Console.WriteLine(path);

    }
    else if (Directory.Exists(path + @"\" + commands[1]))
    {
        Console.WriteLine(path + @"\" + commands[1]);
        path = path + @"\" + commands[1];
    }
    else
    {
        Console.WriteLine("there is no such folder");
    }

}


void FullPath()
{
    if (Directory.Exists(path))
    {
        Console.WriteLine(dirInfo.FullName);
    }
    else
    {
        Console.WriteLine("Command not found");
    }
}