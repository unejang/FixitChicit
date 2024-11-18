using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using FixitChicit.MVVM.Models;
using FixitChicit.Services;
using PropertyChanged;


namespace FixitChicit.MVVM.ViewModels;

[AddINotifyPropertyChangedInterface]
public class DetailPageShoeViewModel
{
    FirestoreService _firestoreService;

    public ObservableCollection<DetailShoe> DetailShoes { get; set; } = [];
    public DetailShoe CurrentDetailShoe{ get; set; }

    public ICommand Reset { get; set; }
    public ICommand AddOrUpdateCommand { get; set; }
    public ICommand DeleteCommand { get; set; }

    public DetailPageShoeViewModel(FirestoreService firestoreService)
    {
        this._firestoreService = firestoreService;
        this.Refresh();
        Reset = new Command( async () =>
        {
            CurrentDetailShoe = new DetailShoe();
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
        DetailShoes = [];
        var items = await _firestoreService.GetAllDetailShoe();
        foreach (var item in items)
        {
            DetailShoes.Add(item);
        }
    }

    public async Task Save()
    {
       if(string.IsNullOrEmpty(CurrentDetailShoe.Id))
       {
            await _firestoreService.InsertDetailShoe(this.CurrentDetailShoe);
       }
       else{
            await _firestoreService.UpdateDetailShoe(this.CurrentDetailShoe);
       }
    }

    private async Task Refresh()
    {
        CurrentDetailShoe = new DetailShoe();
        await this.GetAll();
    }

    private async Task Delete()
    {
        await _firestoreService.DeleteDetailShoe(this.CurrentDetailShoe.Id);
    }


}

