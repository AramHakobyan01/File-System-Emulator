var os_info = Environment.OSVersion.ToString().Split(' ');
Console.WriteLine(os_info[0]);
var path = "root";
var slash = "";
var dirs = path.Split(slash);
var paths = new Dictionary<int, string>();
var folders = new Dictionary<int, string>();
var files = new Dictionary<int, string>();
int num = 1;


switch (os_info[0])
{
    case "Microsoft":
        slash = @"\";
        break;
    case "Unix":
        slash = "/";
        break;
    case "Linux":
        slash = "/";
        break;
}

while (true)
{
    var command = Console.ReadLine().ToString();
    var commands = command.Split(' ');
    dirs = path.Split(slash);
    switch (commands[0])
    {
        case "":
            break;
        case "ls":
            if (commands.Length > 1)
                if (commands[1].Length >= 1 )
                {
                    Console.WriteLine("Command not found");
                    break;
                }
            Lists();
            break;
        case "pwd":
            if (commands.Length > 1)
                if (commands[1].Length >= 1)
                {
                    Console.WriteLine("Command not found");
                    break;
                }

            FullPath();
            break;
        case "mkdir":
            if (commands[1].Length < 1 || commands.Length != 2)
            {
                Console.WriteLine("Command not found");
                break;
            }
            CreateFolder(commands);
            break;
        case "rm":
            if (commands[1].Length < 1 || commands.Length != 2)
            {
                Console.WriteLine("Command not found");
                break;
            }
            RemoveFile(commands);
            break;
        case "touch":
            if (commands[1].Length < 1 || commands.Length != 2)
            {
                Console.WriteLine("Command not found");
                break;
            }
            CreateFile(commands);
            break;
        case "rmdir":
            if (commands[1].Length < 1 || commands.Length != 2)
            {
                Console.WriteLine("Command not found");
                break;
            }
            RemoveFolder(commands);
            break;
        case "cd":
            if (commands.Length != 2)
            {
                Console.WriteLine("Command not found");
                break;
            }
            AccessesFolder(commands);
            break;
        default:
            Console.WriteLine("Command not found");
            break;
    }
}



void Lists()
{
    foreach (var folder in folders)
    {
            foreach (var p in paths)
            {
                if (p.Key == folder.Key && p.Value == dirs[dirs.Length - 1])
                {
                Console.WriteLine(folder.Value);
             }
            }
    }
    foreach (var file in files)
    {
        foreach (var p in paths)
        {
            if (p.Key == file.Key && p.Value == dirs[dirs.Length - 1])
            {
                Console.WriteLine(file.Value);
            }
        }
    }


}



void CreateFolder(string[] commands)
{
    int count = 0;
    foreach (var folder in folders )
    {
        if (folder.Value == commands[1])
        {
            foreach (var p in paths)
            {
                if(p.Key == folder.Key && p.Value == dirs[dirs.Length - 1])
                {
                    count++;
                    break;
                }
            }
        }
    }
    foreach (var file in files)
    {
        if (file.Value == commands[1])
        {
            foreach (var p in paths)
            {
                if (p.Key == file.Key && p.Value == dirs[dirs.Length - 1])
                {
                    count++;
                    break;
                }
            }
        }
    }

    if (count == 0)
    {
        if (commands[1] != " " && commands[1][0] != '/' && commands[1][0] != ':' && commands[1][0] != '*'
            && commands[1][0] != '?' && commands[1][0] != '"' && commands[1][0] != '<' && commands[1][0] != '>'
            && commands[1][0] != '|' && commands[1][0] != 92 )
        {
            folders.Add(num, commands[1]);
            paths.Add(num, dirs[dirs.Length - 1]);
            num++;
            //dirInfo.CreateSubdirectory(commands[1]);
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
    int count = 0;
    foreach (var folder in folders)
    {
        if (folder.Value == commands[1])
        {
            foreach (var p in paths)
            {
                if (p.Key == folder.Key && p.Value == dirs[dirs.Length - 1])
                {
                    count++;
                    break;
                }
            }
        }
    }
    foreach (var file in files)
    {
        if (file.Value == commands[1])
        {
            foreach (var p in paths)
            {
                if (p.Key == file.Key && p.Value == dirs[dirs.Length - 1])
                {
                    count++;
                    break;
                }
            }
        }
    }
    if (count == 0)
    {

        files.Add(num, commands[1]);
        paths.Add(num, dirs[dirs.Length - 1]);
        num++;

    }


    else
    {
        Console.WriteLine("there is already such a file or folder");
    }
}


void RemoveFolder(string[] commands)
{
    int count = 0;
    foreach (var folder in folders)
    {
        if (folder.Value == commands[1])
        {
            foreach (var p in paths)
            {
                if (p.Key == folder.Key && p.Value == dirs[dirs.Length - 1])
                {
                    count = p.Key;
                    break;
                }
            }
        }
    }
    if (count != 0) { 

        folders.Remove(count);
        paths.Remove(count);
    }
    else
    {
        Console.WriteLine("there is no such folder");
    }

}


void RemoveFile(string[] commands)
{
    int count = 0;
    foreach (var file in files)
    {
        if (file.Value == commands[1])
        {
            foreach (var p in paths)
            {
                if (p.Key == file.Key && p.Value == dirs[dirs.Length - 1])
                {
                    count = p.Key;
                    break;
                }
            }
        }
    }
    if (count != 0)
    {

        files.Remove(count);
    }
    else
    {
        Console.WriteLine("there is no such file");
    }
}


void AccessesFolder(string[] commands)
{
    int count = 0;
    foreach (var folder in folders)
    {
        if (folder.Value == commands[1])
        {
            foreach (var p in paths)
            {
                if (p.Key == folder.Key && p.Value == dirs[dirs.Length - 1])
                {
                    count = p.Key;
                    break;
                }
            }
        }
    }
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
    else if (count != 0 && commands[1][0] != '.')
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
    Console.WriteLine(path);
}