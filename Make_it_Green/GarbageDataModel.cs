using System;
using Google.Cloud.Firestore;

namespace Make_it_Green;

public class GarbageDataModel
{
    [FirestoreProperty]
    public string Id {get; set;}
    [FirestoreProperty]
    public string Type {get; set;}
    [FirestoreProperty]
    public double Weight {get; set;}
    [FirestoreProperty]
    public double Price {get; set;}

}
