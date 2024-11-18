using System;
using FixitChicit.MVVM.Models;
using Google.Cloud.Firestore;

namespace FixitChicit.Services;

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
            var stream = await FileSystem.OpenAppPackageFileAsync("fititchicit-firebase-adminsdk-vmuw8-ab9eccf548.json");
            var reader = new StreamReader(stream);
            var contents = reader.ReadToEnd();
            db = new FirestoreDbBuilder
            {
                ProjectId = "fititchicit",

                JsonCredentials = contents
            }.Build();
        }
    }


    //Shirt
    public async Task<List<DetailShirt>> GetAllDetailShirt()
    {
        try
        {
            await SetupFireStore();
            var data = await db.Collection("DetailShirt").GetSnapshotAsync();
            var detailShirts = data.Documents.Select(doc =>
            {
                var detailShirt = new DetailShirt();
                detailShirt.Id = doc.Id;
                
                detailShirt.Name = doc.GetValue<string>("Name");
                detailShirt.Phone = doc.GetValue<string>("phone");
                detailShirt.Address = doc.GetValue<string>("Address");
                detailShirt.Type = doc.GetValue<string>("Type");
                detailShirt.Problem = doc.GetValue<string>("Problem");
                detailShirt.File = doc.GetValue<string>("File");
                return detailShirt;
            }).ToList();
            return detailShirts;
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
        return null;
    }

    public async Task InsertDetailShirt(DetailShirt detailShirt)
    {
        try
        {
            await SetupFireStore();
            var detailShirtData = new Dictionary<string, object>
            {
                { "Name", detailShirt.Name },
                { "Phone", detailShirt.Phone },
                { "Address", detailShirt.Address },
                { "Type", detailShirt.Type },
                { "Problem", detailShirt.Problem },
                { "File", detailShirt.File}

                // Add more fields as needed
            };

            await db.Collection("DetailShirt").AddAsync(detailShirtData);
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public async Task UpdateDetailShirt(DetailShirt detailShirt)
    {
        try
        {
            await SetupFireStore();

            // Manually create a dictionary for the updated data
            var detailShirtData = new Dictionary<string, object>
            {
                { "Name", detailShirt.Name },
                { "Phone", detailShirt.Phone },
                { "Address", detailShirt.Address },
                { "Type", detailShirt.Type },
                { "Problem", detailShirt.Problem },
                 { "File", detailShirt.File}
                // Add more fields as needed
            };

            // Reference the document by its Id and update it
            var docRef = db.Collection("DetailShirt").Document(detailShirt.Id);
            await docRef.SetAsync(detailShirtData, SetOptions.Overwrite);

            StatusMessage = "Sample successfully updated!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public async Task DeleteDetailShirt(string id)
    {
        try
        {
            await SetupFireStore();

            // Reference the document by its Id and delete it
            var docRef = db.Collection("DetailShirt").Document(id);
            await docRef.DeleteAsync();

            StatusMessage = "Sample successfully deleted!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }
    

    //Accesory
    public async Task<List<DetailAccessory>> GetAllDetailAccessory()
    {
        try
        {
            await SetupFireStore();
            var data = await db.Collection("DetailAccessory").GetSnapshotAsync();
            var detailAccessorys = data.Documents.Select(doc =>
            {
                var detailAccessory = new DetailAccessory();
                detailAccessory.Id = doc.Id;
                
                detailAccessory.Name = doc.GetValue<string>("Name");
                detailAccessory.Phone = doc.GetValue<string>("phone");
                detailAccessory.Address = doc.GetValue<string>("Address");
                detailAccessory.Type = doc.GetValue<string>("Type");
                detailAccessory.Problem = doc.GetValue<string>("Problem");
                detailAccessory.File = doc.GetValue<string>("File");
                return detailAccessory;
            }).ToList();
            return detailAccessorys;
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
        return null;
    }

    public async Task InsertDetailAccessory(DetailAccessory detailAccessory)
    {
        try
        {
            await SetupFireStore();
            var detailAccessoryData = new Dictionary<string, object>
            {
                { "Name", detailAccessory.Name },
                { "Phone", detailAccessory.Phone },
                { "Address", detailAccessory.Address },
                { "Type", detailAccessory.Type },
                { "Problem", detailAccessory.Problem },
                 { "File", detailAccessory.File}
                // Add more fields as needed
            };

            await db.Collection("DetailAccessory").AddAsync(detailAccessoryData);
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public async Task UpdateDetailAccessory(DetailAccessory detailAccessory)
    {
        try
        {
            await SetupFireStore();

            // Manually create a dictionary for the updated data
            var detailAccessoryData = new Dictionary<string, object>
            {
                { "Name", detailAccessory.Name },
                { "Phone", detailAccessory.Phone },
                { "Address", detailAccessory.Address },
                { "Type", detailAccessory.Type },
                { "Problem", detailAccessory.Problem },
                 { "File", detailAccessory.File}
                // Add more fields as needed
            };

            // Reference the document by its Id and update it
            var docRef = db.Collection("DetailAccessory").Document(detailAccessory.Id);
            await docRef.SetAsync(detailAccessoryData, SetOptions.Overwrite);

            StatusMessage = "Sample successfully updated!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public async Task DeleteDetailAccessory(string id)
    {
        try
        {
            await SetupFireStore();

            // Reference the document by its Id and delete it
            var docRef = db.Collection("DetailAccessory").Document(id);
            await docRef.DeleteAsync();

            StatusMessage = "Accessory successfully deleted!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }


    //Bag
    public async Task<List<DetailBag>> GetAllDetailBag()
    {
        try
        {
            await SetupFireStore();
            var data = await db.Collection("DetailBag").GetSnapshotAsync();
            var detailBags = data.Documents.Select(doc =>
            {
                var detailBag = new DetailBag();
                detailBag.Id = doc.Id;
                
                detailBag.Name = doc.GetValue<string>("Name");
                detailBag.Phone = doc.GetValue<string>("phone");
                detailBag.Address = doc.GetValue<string>("Address");
                detailBag.Type = doc.GetValue<string>("Type");
                detailBag.Problem = doc.GetValue<string>("Problem");
                detailBag.File = doc.GetValue<string>("File");
                return detailBag;
            }).ToList();
            return detailBags;
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
        return null;
    }

    public async Task InsertDetailBag(DetailBag detailBag)
    {
        try
        {
            await SetupFireStore();
            var detailBagData = new Dictionary<string, object>
            {
                { "Name", detailBag.Name },
                { "Phone", detailBag.Phone },
                { "Address", detailBag.Address },
                { "Type", detailBag.Type },
                { "Problem", detailBag.Problem },
                 { "File", detailBag.File}
                // Add more fields as needed
            };

            await db.Collection("DetailBag").AddAsync(detailBagData);
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public async Task UpdateDetailBag(DetailBag detailBag)
    {
        try
        {
            await SetupFireStore();

            // Manually create a dictionary for the updated data
            var detailBagData = new Dictionary<string, object>
            {
                { "Name", detailBag.Name },
                { "Phone", detailBag.Phone },
                { "Address", detailBag.Address },
                { "Type", detailBag.Type },
                { "Problem", detailBag.Problem },
                 { "File", detailBag.File}
                // Add more fields as needed
            };

            // Reference the document by its Id and update it
            var docRef = db.Collection("DetailBag").Document(detailBag.Id);
            await docRef.SetAsync(detailBagData, SetOptions.Overwrite);

            StatusMessage = "Bag successfully updated!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public async Task DeleteDetailBag(string id)
    {
        try
        {
            await SetupFireStore();

            // Reference the document by its Id and delete it
            var docRef = db.Collection("DetailBag").Document(id);
            await docRef.DeleteAsync();

            StatusMessage = "Bag successfully deleted!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }
    //Pant
    public async Task<List<DetailPant>> GetAllDetailPant()
    {
        try
        {
            await SetupFireStore();
            var data = await db.Collection("DetailPant").GetSnapshotAsync();
            var detailPants = data.Documents.Select(doc =>
            {
                var detailPant = new DetailPant();
                detailPant.Id = doc.Id;
                
                detailPant.Name = doc.GetValue<string>("Name");
                detailPant.Phone = doc.GetValue<string>("phone");
                detailPant.Address = doc.GetValue<string>("Address");
                detailPant.Type = doc.GetValue<string>("Type");
                detailPant.Problem = doc.GetValue<string>("Problem");
                detailPant.File = doc.GetValue<string>("File");
                return detailPant;
            }).ToList();
            return detailPants;
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
        return null;
    }

    public async Task InsertDetailPant(DetailPant detailPant)
    {
        try
        {
            await SetupFireStore();
            var detailPantData = new Dictionary<string, object>
            {
                { "Name", detailPant.Name },
                { "Phone", detailPant.Phone },
                { "Address", detailPant.Address },
                { "Type", detailPant.Type },
                { "Problem", detailPant.Problem },
                { "File", detailPant.File}
                // Add more fields as needed
            };

            await db.Collection("DetailPant").AddAsync(detailPantData);
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public async Task UpdateDetailPant(DetailPant detailPant)
    {
        try
        {
            await SetupFireStore();

            // Manually create a dictionary for the updated data
            var detailPantData = new Dictionary<string, object>
            {
                { "Name", detailPant.Name },
                { "Phone", detailPant.Phone },
                { "Address", detailPant.Address },
                { "Type", detailPant.Type },
                { "Problem", detailPant.Problem },
                 { "File", detailPant.File}
                // Add more fields as needed
            };

            // Reference the document by its Id and update it
            var docRef = db.Collection("DetailPant").Document(detailPant.Id);
            await docRef.SetAsync(detailPantData, SetOptions.Overwrite);

            StatusMessage = "Pant successfully updated!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public async Task DeleteDetailPant(string id)
    {
        try
        {
            await SetupFireStore();

            // Reference the document by its Id and delete it
            var docRef = db.Collection("DetailPant").Document(id);
            await docRef.DeleteAsync();

            StatusMessage = "Pant successfully deleted!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }


    //Shoe
    public async Task<List<DetailShoe>> GetAllDetailShoe()
    {
        try
        {
            await SetupFireStore();
            var data = await db.Collection("DetailShoe").GetSnapshotAsync();
            var detailShoes = data.Documents.Select(doc =>
            {
                var detailShoe = new DetailShoe();
                detailShoe.Id = doc.Id;
                
                detailShoe.Name = doc.GetValue<string>("Name");
                detailShoe.Phone = doc.GetValue<string>("phone");
                detailShoe.Address = doc.GetValue<string>("Address");
                detailShoe.Type = doc.GetValue<string>("Type");
                detailShoe.Problem = doc.GetValue<string>("Problem");
                detailShoe.File = doc.GetValue<string>("File");
                return detailShoe;
            }).ToList();
            return detailShoes;
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
        return null;
    }

    public async Task InsertDetailShoe(DetailShoe detailShoe)
    {
        try
        {
            await SetupFireStore();
            var detailShoeData = new Dictionary<string, object>
            {
                { "Name", detailShoe.Name },
                { "Phone", detailShoe.Phone },
                { "Address", detailShoe.Address },
                { "Type", detailShoe.Type },
                { "Problem", detailShoe.Problem },
                 { "File", detailShoe.File}
                // Add more fields as needed
            };

            await db.Collection("DetailShoe").AddAsync(detailShoeData);
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public async Task UpdateDetailShoe(DetailShoe detailShoe)
    {
        try
        {
            await SetupFireStore();

            // Manually create a dictionary for the updated data
            var detailShoeData = new Dictionary<string, object>
            {
                { "Name", detailShoe.Name },
                { "Phone", detailShoe.Phone },
                { "Address", detailShoe.Address },
                { "Type", detailShoe.Type },
                { "Problem", detailShoe.Problem },
                 { "File", detailShoe.File}
                // Add more fields as needed
            };

            // Reference the document by its Id and update it
            var docRef = db.Collection("DetailShoe").Document(detailShoe.Id);
            await docRef.SetAsync(detailShoeData, SetOptions.Overwrite);

            StatusMessage = "Shoe successfully updated!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public async Task DeleteDetailShoe(string id)
    {
        try
        {
            await SetupFireStore();

            // Reference the document by its Id and delete it
            var docRef = db.Collection("DetailShoe").Document(id);
            await docRef.DeleteAsync();

            StatusMessage = "Shoe successfully deleted!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }


    //Skirt
    public async Task<List<DetailSkirt>> GetAllDetailSkirt()
    {
        try
        {
            await SetupFireStore();
            var data = await db.Collection("DetailSkirt").GetSnapshotAsync();
            var detailSkirts = data.Documents.Select(doc =>
            {
                var detailSkirt = new DetailSkirt();
                detailSkirt.Id = doc.Id;
                
                detailSkirt.Name = doc.GetValue<string>("Name");
                detailSkirt.Phone = doc.GetValue<string>("phone");
                detailSkirt.Address = doc.GetValue<string>("Address");
                detailSkirt.Type = doc.GetValue<string>("Type");
                detailSkirt.Problem = doc.GetValue<string>("Problem");
                detailSkirt.File = doc.GetValue<string>("File");
                return detailSkirt;
            }).ToList();
            return detailSkirts;
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
        return null;
    }

    public async Task InsertDetailSkirt(DetailSkirt detailSkirt)
    {
        try
        {
            await SetupFireStore();
            var detailSkirtData = new Dictionary<string, object>
            {
                { "Name", detailSkirt.Name },
                { "Phone", detailSkirt.Phone },
                { "Address", detailSkirt.Address },
                { "Type", detailSkirt.Type },
                { "Problem", detailSkirt.Problem },
                 { "File", detailSkirt.File}
                // Add more fields as needed
            };

            await db.Collection("DetailSkirt").AddAsync(detailSkirtData);
        }
        catch (Exception ex)
        {

            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public async Task UpdateDetailSkirt(DetailSkirt detailSkirt)
    {
        try
        {
            await SetupFireStore();

            // Manually create a dictionary for the updated data
            var detailSkirtData = new Dictionary<string, object>
            {
                { "Name", detailSkirt.Name },
                { "Phone", detailSkirt.Phone },
                { "Address", detailSkirt.Address },
                { "Type", detailSkirt.Type },
                { "Problem", detailSkirt.Problem },
                { "File", detailSkirt.File}
                // Add more fields as needed
            };

            // Reference the document by its Id and update it
            var docRef = db.Collection("DetailSkirt").Document(detailSkirt.Id);
            await docRef.SetAsync(detailSkirtData, SetOptions.Overwrite);

            StatusMessage = "Skirt successfully updated!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }

    public async Task DeleteDetailSkirt(string id)
    {
        try
        {
            await SetupFireStore();

            // Reference the document by its Id and delete it
            var docRef = db.Collection("DetailSkirt").Document(id);
            await docRef.DeleteAsync();

            StatusMessage = "Skirt successfully deleted!";
        }
        catch (Exception ex)
        {
            StatusMessage = $"Error: {ex.Message}";
        }
    }
}