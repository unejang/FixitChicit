using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using FixitChicit.MVVM.Models;
using FixitChicit.Services;
using PropertyChanged;


namespace FixitChicit.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class DetailPageBagViewModel
{
    FirestoreService _firestoreService;

    public ObservableCollection<DetailBag> DetailBags { get; set; } = [];
    public DetailBag CurrentDetailBag{ get; set; }

    public ICommand Reset { get; set; }
    public ICommand AddOrUpdateCommand { get; set; }
    public ICommand DeleteCommand { get; set; }

    public DetailPageBagViewModel(FirestoreService firestoreService)
    {
        this._firestoreService = firestoreService;
        this.Refresh();
        Reset = new Command( async () =>
        {
            CurrentDetailBag = new DetailBag();
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
        DetailBags = [];
        var items = await _firestoreService.GetAllDetailBag();
        foreach (var item in items)
        {
            DetailBags.Add(item);
        }
    }

    public async Task Save()
    {
       if(string.IsNullOrEmpty(CurrentDetailBag.Id))
       {
            await _firestoreService.InsertDetailBag(this.CurrentDetailBag);
       }
       else{
            await _firestoreService.UpdateDetailBag(this.CurrentDetailBag);
       }
    }

    private async Task Refresh()
    {
        CurrentDetailBag = new DetailBag();
        await this.GetAll();
    }

    private async Task Delete()
    {
        await _firestoreService.DeleteDetailBag(this.CurrentDetailBag.Id);
    }


}