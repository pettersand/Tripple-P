using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Tripple_P.Models;



namespace Tripple_P.Services
{
    internal class ProjectManager
    {
        public static Project CreateNewProject(string projectName, string projectPath)
        {
            // Create the project folder
            string projectFolder = Path.Combine(projectPath, projectName);
            Directory.CreateDirectory(projectFolder);

            // Create subfolders
            Directory.CreateDirectory(Path.Combine(projectFolder, "Planning"));
            Directory.CreateDirectory(Path.Combine(projectFolder, "Progress"));
            Directory.CreateDirectory(Path.Combine(projectFolder, "Production"));
            Directory.CreateDirectory(Path.Combine(projectFolder, "Assets"));

            // Create metadata file
            Project project = new Project
            {
                ProjectName = projectName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            string metadataJson = JsonConvert.SerializeObject(project, Formatting.Indented);
            File.WriteAllText(Path.Combine(projectFolder, ".metadata.json"), metadataJson);

            return project;
        }

        public static Project OpenExistingProject(string filePath)
        {
            string metadataJson = File.ReadAllText(filePath);

            Project project = JsonConvert.DeserializeObject<Project>(metadataJson);

            return project;
        }

        public static void SaveProject(Project project, string projectFolder)
        {
            project.ModifiedDate = DateTime.Now;

            string projectJson = JsonConvert.SerializeObject(project, Formatting.Indented);
            File.WriteAllText(Path.Combine(projectFolder, ".metadata.json"), projectJson);
        }
    }
}
