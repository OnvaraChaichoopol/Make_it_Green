using System;
using Google.Cloud.Firestore;

namespace Make_it_Green.Services;

public class FirestoreService
{
    private FirestoreDb db;
    public string StatusMessage;

    public FirestoreService()
    {
        this.SetupFireStore();
    }
    private async Task SetupFireStore()
    {
        if (db == null)
        {
            var stream = await FileSystem.OpenAppPackageFileAsync("make-it-green-e30d2-firebase-adminsdk-dflto-28237ac1a6.json");
            var reader = new StreamReader(stream);
            var contents = reader.ReadToEnd();
            db = new FirestoreDbBuilder
            {
                ProjectId = "make-it-green-e30d2",

                JsonCredentials = contents
            }.Build();
        }
    }
    public async Task<List<GarbageDataModel>> GetAllGarbageData()
    {
        try
        {
            await SetupFireStore();
            var data = await db.Collection("GarbageList").GetSnapshotAsync();
            var AllGarbageData = data.Documents.Select(doc =>
            {
                var GarbageData = new GarbageDataModel();
                GarbageData.Id = doc.Id;
                GarbageData.Type = doc.GetValue<string>("Type");
                GarbageData.Weight = doc.GetValue<double>("Weight");
                GarbageData.Price = doc.GetValue<double>("Price");
                return GarbageData;
            }).ToList();
            return AllGarbageData;
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
        return null;
    }


    public async Task InsertGarbageData(GarbageDataModel GarbageData)
    {
        try
        {
            await SetupFireStore();
            var Garbage_Data = new Dictionary<string, object>
            {
                { "Type", GarbageData.Type },
                { "Weight", GarbageData.Weight },
                { "Price", GarbageData.Price }

                // Add more fields as needed
            };

            await db.Collection("GarbageList").AddAsync(Garbage_Data);
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
    }
    public async Task UpdateGarbageData(GarbageDataModel GarbageData)
    {
        try
        {
            await SetupFireStore();

            // Manually create a dictionary for the updated data
            var Garbage_Data = new Dictionary<string, object>
            {
                { "Type", GarbageData.Type },
                { "Weight", GarbageData.Weight },
                { "Price", GarbageData.Price }
                // Add more fields as needed
            };

            // Reference the document by its Id and update it
            var docRef = db.Collection("GarbageList").Document(GarbageData.Id);
            await docRef.SetAsync(Garbage_Data, SetOptions.Overwrite);

            StatusMessage = "Garbage List successfully updated!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }
    public async Task DeleteGarbageData(string id)
    {
        try
        {
            await SetupFireStore();

            // Reference the document by its Id and delete it
            var docRef = db.Collection("GarbageList").Document(id);
            await docRef.DeleteAsync();

            StatusMessage = "Garbage List successfully deleted!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }
}