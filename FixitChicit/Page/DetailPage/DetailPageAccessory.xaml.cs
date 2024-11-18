using FixitChicit.MVVM.ViewModels;
using FixitChicit.Services;
using FixitChicit.MVVM.Models;
using Google.Cloud.Firestore;

namespace FixitChicit.Page.DetailPage;

public partial class DetailPageAccessory : ContentPage
{
	public DetailPageAccessory()
	{
		InitializeComponent();
        var firestoreService = new FirestoreService();
		BindingContext = new  DetailPageAccessoryViewModel(firestoreService);
	}

private async void SubmitAccessory(object sender, EventArgs e)
{
    // ตรวจสอบว่า Entry ทุกตัวมีข้อมูลครบหรือไม่
            if (string.IsNullOrWhiteSpace(EntryName.Text) ||
                string.IsNullOrWhiteSpace(EntryPhone.Text)  ||
                string.IsNullOrWhiteSpace(EntryAddress.Text) ||
                EntryType.SelectedItem == null  || 
                string.IsNullOrWhiteSpace(EntryProblem.Text) )
            {
                // ถ้ามีข้อมูลที่ไม่ได้กรอก จะแสดง Alert
                await DisplayAlert("Incomplete Information", "Please fill in all fields.", "OK");
            }

            else
            {
    
                // โค้ดสำหรับบันทึกข้อมูลเมื่อข้อมูลครบถ้วน
                await DisplayAlert(
      "Information",
      $"Your order has been placed \n Name: {EntryName.Text} \n Phone: {EntryPhone.Text} \n Address: {EntryAddress.Text} \n Types: {EntryType.SelectedItem} \n Problems: {EntryProblem.Text}\n ",
      "OK");
    await Navigation.PushAsync(new HistoryPage());  // แทนที่ "HistoryPage" ด้วยหน้าที่คุณต้องการไป
            }
}
}