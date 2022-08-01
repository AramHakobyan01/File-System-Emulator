
var os_info = Environment.OSVersion.ToString().Split(' ');
Console.WriteLine(os_info[0]);
var path = "root";
DirectoryInfo dirInfo = new DirectoryInfo(path);
if (!dirInfo.Exists)
{
    dirInfo.Create();
}
var slash = "";
switch (os_info[0])
{
    case "Microsoft":
        slash = @"\";
        break;
    case "MacOS":
        slash = "/";
        break;
    case "Linux":
        slash = "/";
        break;
}

while (true)
{
    dirInfo = new DirectoryInfo(path);
    var command = Console.ReadLine().ToString();
    var commands = command.Split(' ');
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
            if (commands.Length != 2)
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

        var dirs = Directory.GetFileSystemEntries(path);
        for (int i = 0; i < dirs.Length; i++)
        {
            string[] name = dirs[i].Split(slash);
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
    if (!Directory.Exists(path + slash + commands[1]))
    {
        if (commands[1][0] != '/' && commands[1][0] != ':' && commands[1][0] != '*'
            && commands[1][0] != '?' && commands[1][0] != '"' && commands[1][0] != '<' && commands[1][0] != '>'
            && commands[1][0] != '|' && commands[1][0] != 92)
        {
            dirInfo.CreateSubdirectory(commands[1]);
        }
        else
            Console.WriteLine(@"A folder name can`t contain any of the following charecters: \/:*?<>|" + '"');

    }
    else
    {
        Console.WriteLine("there is already such a file or folder");
    }

}


void CreateFile(string[] commands)
{
    if (!File.Exists(path + slash + commands[1]))
    {
        using (FileStream f = File.Create(path + slash + commands[1]))
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
    if (Directory.Exists(path + slash + commands[1]))
    {
        var a = Directory.GetFileSystemEntries(path + slash + commands[1]);
        if (a.Length < 1)
        {
            Directory.Delete(path + slash + commands[1]); ;
        }
        else
        {
            Console.WriteLine("this folder is not empty");
        }
    }
    else
    {
        Console.WriteLine("there is no such folder");
    }

}


void RemoveFile(string[] commands)
{
    if (File.Exists(path + slash + commands[1]))
    {
        File.Delete(path + slash + commands[1]);
    }
    else
    {
        Console.WriteLine("there is no such file");
    }
}


void AccessesFolder(string[] commands)
{
    if (commands[1] == ".." && commands[1].Length < 3)
    {
        var dirs = path.Split(slash);
        path = "";
        for (int i = 0; true;)
        {
            path = path + dirs[i];
            i++;
            if (i >= dirs.Length - 1)
                break;
            path += slash;
        }
        Console.WriteLine(path);

    }
    else if (Directory.Exists(path + slash + commands[1]) && commands[1][0] != '.')
    {
        if (commands[1][0] != '/' && commands[1][0] != ':' && commands[1][0] != '*'
            && commands[1][0] != '?' && commands[1][0] != '"' && commands[1][0] != '<' && commands[1][0] != '>'
            && commands[1][0] != '|' && commands[1][0] != 92 && commands[1][0] != '.')
        {
            Console.WriteLine(path + slash + commands[1]);
            path = path + slash + commands[1];

        }
        else
            Console.WriteLine(@"A folder name can`t contain any of the following charecters: \/:*?<>|" + '"');
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