using System.Text.Json;
using ZooApp.WebAPI.Controller.Contract;
using ZooApp.WebAPI.Domain;
using ZooApp.WebAPI.Infra.Types;

namespace ZooApp.WebAPI.Repository;

public class AnimalFileRepository: IAnimalFileRepository
{
    private readonly string _jsonFilePath;

    public AnimalFileRepository(string jsonFilePath)
    {
        _jsonFilePath = jsonFilePath;
    }

    public async Task<List<Animal>> GetAnimals()
    {
        try
        {
            string jsonString = await File.ReadAllTextAsync(_jsonFilePath);
            if(string.IsNullOrEmpty(jsonString))
            {
                return [];
            }

            List<Animal> animals = [];
            
            try
            {
                List<AnimalJson>? animalsFromJson = [];
                animalsFromJson = JsonSerializer.Deserialize<List<AnimalJson>>(jsonString);         

                if(animalsFromJson == null)
                {
                    return [];
                }

                int count = 0;
                animalsFromJson.ForEach(animalJson =>
                {
                    Animal animal = new()
                    {
                        Name = animalJson.name,
                        UUID = animalJson.id,
                        ID = count,
                        SoundFileName = animalJson.fileNameSound,
                        SoundUrl = animalJson.urlSound,
                        ImageUrl = animalJson.imageUrl
                    };
                    animals.Add(animal);
                    count++;
                });

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deserializing animals from file: {ex.Message}");
                return [];
            }

            return animals;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading animals from file: {ex.Message}");
            return [];
        }

    }
}