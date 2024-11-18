using System;
using Google.Cloud.Firestore;

namespace FixitChicit.MVVM.Models;

public class DetailAccessory
{
    [FirestoreProperty]
    public string Id{ get; set; }

    [FirestoreProperty]
    public string Name { get; set; }


    [FirestoreProperty]
    public string Phone { get; set; }


    [FirestoreProperty]
    public string Address{ get; set; }
    
    [FirestoreProperty]
    public string Type{ get; set; }
    
    [FirestoreProperty]
    public string Problem{ get; set; }

    [FirestoreProperty]
    public string File{ get; set; }

}
