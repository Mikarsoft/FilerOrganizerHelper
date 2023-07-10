
namespace FilerOrganizerHelper
{
    public static class FileOrganizerHelperTool
    {
        public static void Organize(string[] args)
        {
            string currentDir = Directory.GetCurrentDirectory();
            CommandTypes command = CheckCommands(args);

            switch (command)
            {
                case CommandTypes.RenameFiles:
                    Console.WriteLine("Renaming files removing 'spaces' and 'parenthesis'..");
                    Console.WriteLine("");
                    Console.WriteLine("Searching files in the folder..");
                    Console.WriteLine("");

                    string[] myFiles = Directory.GetFiles(currentDir, "*.*", SearchOption.TopDirectoryOnly);

                    if(myFiles.Length > 0)
                    {
                        Console.WriteLine($"{myFiles.Length} files found in the folder..");
                        Console.WriteLine("");

                        foreach (string file in myFiles)
                        {
                            string fileName = Path.GetFileName(file);
                            string newFile = fileName.Replace(" ", "_").Replace("(", "").Replace(")", "");
                            Console.WriteLine($"Renaming {fileName} to {newFile}");
                            string newFileName = Path.Combine(currentDir,newFile);
                            File.Move(file, newFileName);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No files found in the folder.");
                        Console.WriteLine("");
                    }

                    break;
                default:
                    Console.WriteLine("Unrecognized command.");
                    Console.WriteLine("");
                    break;
            }

            Console.WriteLine("Process Exited");
        }

        public static CommandTypes CheckCommands(string[] arguments)
        {
            if(arguments.Length == 1)
            {
                if (arguments[0].ToLower() == "rename")
                {
                    return CommandTypes.RenameFiles;
                }
            }

            return CommandTypes.Default;
        }
    }
}
