using System.Reflection;

public class JsonResourceLoader
{
    public string LoadJSON()
    {
        string jsonContent = "";

        try
        {
            // Name of the embedded resource
            string resourceName = "DataAccessLayer.json.words.json";

            // Get the current assembly
            var assembly = Assembly.GetExecutingAssembly();

            // Read the embedded resource as a stream
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new FileNotFoundException($"Resource '{resourceName}' not found.");
                }

                // Read the stream into a string
                using (StreamReader reader = new StreamReader(stream))
                {
                    jsonContent = reader.ReadToEnd();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        return jsonContent;
    }
}
