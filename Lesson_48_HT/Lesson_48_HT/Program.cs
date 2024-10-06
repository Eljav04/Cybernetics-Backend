using MyColection.Generic;

MyList<decimal> decimal_array = new() {1,1,5,2,8,10.3m,12};

Console.WriteLine("Default list (showed via foreach func) : ");
foreach (decimal item in decimal_array)
{
    Console.Write(item + " ");
}

Console.Write("\nCount: {0} Capacity: {1}", decimal_array.Count, decimal_array.Capacity);

Console.WriteLine("\n\n========================");

Console.WriteLine("AddRange function: ");

decimal_array.AddRange(new(){ 8, 7 });
MyList<decimal>.ShowItems(decimal_array);
Console.Write("\nCount: {0} Capacity: {1}", decimal_array.Count, decimal_array.Capacity);

Console.WriteLine("\n\n========================");

Console.WriteLine("Insert function (44 in 4th index): ");

decimal_array.Insert(4, 44);
MyList<decimal>.ShowItems(decimal_array);
Console.Write("\nCount: {0} Capacity: {1}", decimal_array.Count, decimal_array.Capacity);

Console.WriteLine("\n\n========================");

Console.WriteLine("InsertRange function (55,66 in 2nd index): ");

decimal_array.InsertRange(2, new() {55,66});
MyList<decimal>.ShowItems(decimal_array);
Console.Write("\nCount: {0} Capacity: {1}", decimal_array.Count, decimal_array.Capacity);

Console.WriteLine("\n\n========================");

Console.WriteLine("Sort function: ");

decimal_array.Sort();
MyList<decimal>.ShowItems(decimal_array);

Console.WriteLine("\n\n========================");

Console.WriteLine("Max less than 5 function: ");

Console.WriteLine("Result: " + decimal_array.MaxLessThan(5));


Console.WriteLine("\n\n========================");

Console.WriteLine("Min function greater than 9: ");

Console.WriteLine("Result: " + decimal_array.MinGreaterThan(9));

Console.WriteLine("\n\n========================");

Console.WriteLine("Reverse function: ");

decimal_array.Reverse();
MyList<decimal>.ShowItems(decimal_array);

Console.WriteLine("\n\n========================");

Console.WriteLine("Remove 10.3 and show its index: ");

Console.WriteLine("Its index: " + decimal_array.FindIndex(10.3m));
decimal_array.Remove(10.3m);
MyList<decimal>.ShowItems(decimal_array);
Console.Write("\nCount: {0} Capacity: {1}", decimal_array.Count, decimal_array.Capacity);

Console.WriteLine("\n\n========================");

Console.WriteLine("Remove all 1");

decimal_array.RemoveAll(1);
MyList<decimal>.ShowItems(decimal_array);
Console.Write("\nCount: {0} Capacity: {1}", decimal_array.Count, decimal_array.Capacity);

Console.WriteLine("\n\n========================");

Console.WriteLine("Remove at 3 index");

decimal_array.RemoveAt(3);
MyList<decimal>.ShowItems(decimal_array);
Console.Write("\nCount: {0} Capacity: {1}", decimal_array.Count, decimal_array.Capacity);

Console.WriteLine("\n\n========================");

Console.WriteLine("Clear function");

decimal_array.Clear();
MyList<decimal>.ShowItems(decimal_array);
Console.Write("\nCount: {0} Capacity: {1}", decimal_array.Count, decimal_array.Capacity);

Console.WriteLine("\n\n========================");

Console.WriteLine("TrimExcess function");

decimal_array.TrimExcess();
Console.Write("\nCount: {0} Capacity: {1}", decimal_array.Count, decimal_array.Capacity);

Console.WriteLine("\n\n========================");




Console.ReadKey();
