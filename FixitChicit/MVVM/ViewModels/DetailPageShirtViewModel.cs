using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using FixitChicit.MVVM.Models;
using FixitChicit.Services;
using PropertyChanged;


namespace FixitChicit.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class DetailPageShirtViewModel
{
    FirestoreService _firestoreService;

    public ObservableCollection<DetailShirt> DetailShirts { get; set; } = [];
    public DetailShirt CurrentDetailShirt{ get; set; }

    public ICommand Reset { get; set; }
    public ICommand AddOrUpdateCommand { get; set; }
    public ICommand DeleteCommand { get; set; }

    public DetailPageShirtViewModel(FirestoreService firestoreService)
    {
        this._firestoreService = firestoreService;
        this.Refresh();
        Reset = new Command( async () =>
        {
            CurrentDetailShirt = new DetailShirt();
            await this.Refresh();
        }
        );
        AddOrUpdateCommand = new Command(async () =>
        {
            await this.Save();
            await this.Refresh();
        });
        DeleteCommand = new Command(async () =>
        {
            await this.Delete();
            await this.Refresh();
        });

    }

    public async Task GetAll()
    {
        DetailShirts = [];
        var items = await _firestoreService.GetAllDetailShirt();
        foreach (var item in items)
        {
            DetailShirts.Add(item);
        }
    }

    public async Task Save()
    {
       if(string.IsNullOrEmpty(CurrentDetailShirt.Id))
       {
            await _firestoreService.InsertDetailShirt(this.CurrentDetailShirt);
       }
       else{
            await _firestoreService.UpdateDetailShirt(this.CurrentDetailShirt);
       }
    }

    private async Task Refresh()
    {
        CurrentDetailShirt = new DetailShirt();
        await this.GetAll();
    }

    private async Task Delete()
    {
        await _firestoreService.DeleteDetailShirt(this.CurrentDetailShirt.Id);
    }


}
