using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using FixitChicit.MVVM.Models;
using FixitChicit.Services;
using PropertyChanged;


namespace FixitChicit.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class DetailPagePantViewModel
{
    FirestoreService _firestoreService;

    public ObservableCollection<DetailPant> DetailPants { get; set; } = [];
    public DetailPant CurrentDetailPant{ get; set; }

    public ICommand Reset { get; set; }
    public ICommand AddOrUpdateCommand { get; set; }
    public ICommand DeleteCommand { get; set; }

    public DetailPagePantViewModel(FirestoreService firestoreService)
    {
        this._firestoreService = firestoreService;
        this.Refresh();
        Reset = new Command( async () =>
        {
            CurrentDetailPant = new DetailPant();
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
        DetailPants = [];
        var items = await _firestoreService.GetAllDetailPant();
        foreach (var item in items)
        {
            DetailPants.Add(item);
        }
    }

    public async Task Save()
    {
       if(string.IsNullOrEmpty(CurrentDetailPant.Id))
       {
            await _firestoreService.InsertDetailPant(this.CurrentDetailPant);
       }
       else{
            await _firestoreService.UpdateDetailPant(this.CurrentDetailPant);
       }
    }

    private async Task Refresh()
    {
        CurrentDetailPant = new DetailPant();
        await this.GetAll();
    }

    private async Task Delete()
    {
        await _firestoreService.DeleteDetailPant(this.CurrentDetailPant.Id);
    }


}
