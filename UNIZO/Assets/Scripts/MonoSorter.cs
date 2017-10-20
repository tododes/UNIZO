using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSorter<T> where T : UnityEngine.Object {

    public static void Sort(T[] data){
        Sort(data, 0, data.Length - 1);
    }

    private static void Sort(T[] data, int low, int high){
        int mid;
        if(low < high){
            mid = (low + high) / 2;
            Sort(data, low, mid);
            Sort(data, mid + 1, high);
            Merge(data, low, mid, high);
        }
    }

    private static void Merge(T[] data, int low, int mid, int high){
        int min = low;
        int counter = 0;
        int afterMid = mid + 1;
        T[] temp = new T[high - low + 1];

        while(min <= mid && afterMid <= high){
            if(data[min].name.CompareTo(data[afterMid].name) == -1){
                temp[counter] = data[min];
                min++;
                counter++;
            }
            else{
                temp[counter] = data[afterMid];
                afterMid++;
                counter++;
            }
        }

        while (min <= mid){
            temp[counter] = data[min];
            min++;
            counter++;
        }

        while (afterMid <= high){
            temp[counter] = data[afterMid];
            afterMid++;
            counter++;
        }

        for(int i = low; i <= high; i++){
            data[i] = temp[i - low];
        }
    }
}
