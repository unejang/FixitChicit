using FixitChicit.MVVM.ViewModels;
using FixitChicit.Services;
using FixitChicit.MVVM.Models;
using Google.Cloud.Firestore;

namespace FixitChicit.Page.DetailPage;

public partial class DetailPageBag : ContentPage
{
	public DetailPageBag()
	{
		InitializeComponent();
        var firestoreService = new FirestoreService();
        BindingContext = new DetailPageBagViewModel(firestoreService);
	}

private async void SubmitBag(object sender, EventArgs e)
{
    // ตรวจสอบว่าผู้ใช้ได้เลือกประเภทจาก Picker หรือไม่
    if (EntryType.SelectedItem != null)
    {
        // ดึงค่าที่เลือกจาก Picker
        string selectedType = EntryType.SelectedItem.ToString();

        // แสดง DisplayAlert
        await DisplayAlert(
            "Information", 
            $"Your order has been placed \n Name: {EntryName.Text} \n Phone: {EntryPhone.Text} \n Address: {EntryAddress.Text} \n Type: {selectedType} \n Problems: {EntryProblem.Text} \n File: {EntryFile.Text}", 
            "OK");

        // เมื่อผู้ใช้กด "OK", นำทางไปยังหน้าถัดไป
        await Navigation.PushAsync(new HistoryPage());  // แทนที่ "HistoryPage" ด้วยหน้าที่คุณต้องการไป
    }
    else
    {
        // ถ้าผู้ใช้ไม่ได้เลือกประเภทจาก Picker ให้แสดงข้อความแจ้งเตือน
        await DisplayAlert("Error", "Please select a category.", "OK");
    }
}
}