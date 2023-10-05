using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;



namespace Tripple_P.Services
{
    internal class ProjectManager
    {
        public void CreateNewProject(string projectName, string projectPath)
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
            var metadata = new
            {
                ProjectName = projectName,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now
            };

            string metadataJson = JsonConvert.SerializeObject(metadata, Formatting.Indented);
            File.WriteAllText(Path.Combine(projectFolder, ".metadata.json"), metadataJson);
        }

    }
}
