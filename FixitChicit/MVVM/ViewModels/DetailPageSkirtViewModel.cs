using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using FixitChicit.MVVM.Models;
using FixitChicit.Services;
using PropertyChanged;


namespace FixitChicit.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class DetailPageSkirtViewModel
{
    FirestoreService _firestoreService;

    public ObservableCollection<DetailSkirt> DetailSkirts { get; set; } = [];
    public DetailSkirt CurrentDetailSkirt{ get; set; }

    public ICommand Reset { get; set; }
    public ICommand AddOrUpdateCommand { get; set; }
    public ICommand DeleteCommand { get; set; }

    public DetailPageSkirtViewModel(FirestoreService firestoreService)
    {
        this._firestoreService = firestoreService;
        this.Refresh();
        Reset = new Command( async () =>
        {
            CurrentDetailSkirt = new DetailSkirt();
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
        DetailSkirts = [];
        var items = await _firestoreService.GetAllDetailSkirt();
        foreach (var item in items)
        {
            DetailSkirts.Add(item);
        }
    }

    public async Task Save()
    {
       if(string.IsNullOrEmpty(CurrentDetailSkirt.Id))
       {
            await _firestoreService.InsertDetailSkirt(this.CurrentDetailSkirt);
       }
       else{
            await _firestoreService.UpdateDetailSkirt(this.CurrentDetailSkirt);
       }
    }

    private async Task Refresh()
    {
        CurrentDetailSkirt = new DetailSkirt();
        await this.GetAll();
    }

    private async Task Delete()
    {
        await _firestoreService.DeleteDetailSkirt(this.CurrentDetailSkirt.Id);
    }


}