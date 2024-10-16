﻿using System;

namespace Lesson_50_HT.Services.RandomGenerator
{
	internal static partial class RandomGenerator
    {
        public static string GeneratePassword()
        {
            Random random = new Random();
            int new_password = random.Next(1000, 9999);
            return new_password.ToString();
        }

    }

    internal static partial class RandomGenerator<T>
    {
        public static void ShuffleList(ref List<T> list)
        {
            Random random = new();

            for (int i = 0; i < list.Count; i++)
            {
                int first = random.Next(0, list.Count);
                int second = random.Next(0, list.Count);

                T value = list[first];
                list[first] = list[second];
                list[second] = value;
            }
        }
    }





}

