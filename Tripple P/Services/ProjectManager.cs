using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
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

            // Create metadata file
            Project project = new Project
            {
                ProjectName = projectName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            string projectJson = JsonConvert.SerializeObject(project, Formatting.Indented);
            File.WriteAllText(Path.Combine(projectFolder, ".metadata.ppp"), projectJson);

            return project;
        }

        public static Project OpenExistingProject(string filePath)
        {
            string projectJson = File.ReadAllText(filePath);

            Project project = JsonConvert.DeserializeObject<Project>(projectJson);

            return project;
        }

        public static void SaveProject(Project project, string projectFolder)
        {
            Debug.WriteLine("Entering SaveProject");

            project.ModifiedDate = DateTime.Now;
            Debug.WriteLine($"Before Serialization - ProjectName: {project.ProjectName}, ProjectDescription: {project.PlanningData.BrainstormData.ProjectDescription}, Features Count: {project.PlanningData.BrainstormData.Features.Count}");

            string projectJson = JsonConvert.SerializeObject(project, Formatting.Indented);
            File.WriteAllText(Path.Combine(projectFolder, ".metadata.ppp"), projectJson);

            Debug.WriteLine($"Project saved to {Path.Combine(projectFolder, ".metadata.ppp")}");

            Debug.WriteLine("Exiting SaveProject");
        }
    }
}
