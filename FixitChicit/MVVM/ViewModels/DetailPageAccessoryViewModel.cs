using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using FixitChicit.MVVM.Models;
using FixitChicit.Services;
using PropertyChanged;


namespace FixitChicit.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class DetailPageAccessoryViewModel
{
    FirestoreService _firestoreService;

    public ObservableCollection<DetailAccessory> DetailAccessorys { get; set; } = [];
    public DetailAccessory CurrentDetailAccessory{ get; set; }

    public ICommand Reset { get; set; }
    public ICommand AddOrUpdateCommand { get; set; }
    public ICommand DeleteCommand { get; set; }

    public DetailPageAccessoryViewModel(FirestoreService firestoreService)
    {
        this._firestoreService = firestoreService;
        this.Refresh();
        Reset = new Command( async () =>
        {
            CurrentDetailAccessory = new DetailAccessory();
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
        DetailAccessorys = [];
        var items = await _firestoreService.GetAllDetailAccessory();
        foreach (var item in items)
        {
            DetailAccessorys.Add(item);
        }
    }

    public async Task Save()
    {
       if(string.IsNullOrEmpty(CurrentDetailAccessory.Id))
       {
            await _firestoreService.InsertDetailAccessory(this.CurrentDetailAccessory);
       }
       else{
            await _firestoreService.UpdateDetailAccessory(this.CurrentDetailAccessory);
       }
    }

    private async Task Refresh()
    {
        CurrentDetailAccessory = new DetailAccessory();
        await this.GetAll();
    }

    private async Task Delete()
    {
        await _firestoreService.DeleteDetailAccessory(this.CurrentDetailAccessory.Id);
    }


}