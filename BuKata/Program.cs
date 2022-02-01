﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace KataTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Kata.CreatePhoneNumber(new int[] { 0, 8, 3, 4, 5, 6, 7, 8, 9, 0 }));

            Console.WriteLine(Kata.XO("asdaXXOO"));

            Console.WriteLine(Kata.Solution(10));

            Console.WriteLine(Kata.Rgb(-20, 255, 255));

            Console.WriteLine(Kata.PigIt("Hello world !"));

            Console.WriteLine(Kata.UniqueInOrder("AAAABBBCCDAABBB"));

            Console.WriteLine(Kata.DeleteNth(new int[] { 3, 1, 2, 3, 2, 3, 3, 2, 2, 2 }, 1));
        }


        public class Kata
        {
            public static string CreatePhoneNumber(int[] numbers)
            {

                string PhoneNumber = "";

                for (int i = 0; i < numbers.Length; i++)
                {
                    PhoneNumber = PhoneNumber + numbers[i].ToString();
                }

                PhoneNumber = uint.Parse(PhoneNumber).ToString("(000) 000-0000");

                return PhoneNumber;
            }

            public static bool XO(string input)
            {

                int _countX = 0;
                int _countO = 0;

                char[] _arrChar = input.ToLower().ToCharArray();

                for (int i = 0; i < _arrChar.Length; i++)
                {
                    if (_arrChar[i] == 'x')
                    {
                        _countX++;
                    }

                    if (_arrChar[i] == 'o')
                    {
                        _countO++;
                    }
                }

                return _countX == _countO;

            }

            public static int Solution(int value)
            {
                int _sum = 0;

                int[] _arr = new int[value];


                for (int i = 0; i < _arr.Length; i++)
                {

                    _arr[i] = i;

                    if (_arr[i] % 3 == 0 || _arr[i] % 5 == 0)
                    {
                        _sum = _sum + _arr[i];
                    }

                    if (_arr[i] % 3 == 0 && _arr[i] % 5 == 0)
                    {
                        _sum = _sum - _arr[i];
                    }
                }

                return _sum;
            }

            public static string Rgb(int r, int g, int b)
            {
                int byteProove(int x)
                {
                    if (x <= 0)
                    {
                        return 0;
                    }
                    else if (x >= 255)
                    {
                        return 255;
                    }
                    else
                    {
                        return x;
                    }
                }

                return byteProove(r).ToString("X2") + byteProove(g).ToString("X2") + byteProove(b).ToString("X2");
            }

            public static string PigIt(string str)
            {

                string[] arrStr = str.Split(' ');

                string newstr = "";

                for (int i = 0; i < arrStr.Length; i++)
                {
                    char[] arrChar = arrStr[i].ToCharArray();

                    char first = arrChar[0];

                    if (arrChar.Length > 1)
                    {

                        for (int j = 1; j < arrChar.Length; j++)
                        {
                            arrChar[j - 1] = arrChar[j];
                        }

                        arrChar[arrChar.Length - 1] = first;

                        for (int k = 0; k < arrChar.Length; k++)
                        {
                            newstr = newstr + arrChar[k];
                        }

                        newstr = newstr + "ay ";
                    }
                    else
                    {
                        newstr = newstr + first + " ";
                    }
                }


                newstr = newstr.Substring(0, newstr.Length - 1);

                return newstr;
            }

            public static string PigIt2(string str)
            {
                return string.Join(" ", str.Split(' ').Select(w => w.Any(char.IsPunctuation) ? w : w.Substring(1) + w[0] + "ay"));
            }

            public static string PigIt3(string str)
            {
                string s = "";

                foreach (string word in str.Split(" "))
                {
                    string word2 = word.Substring(1, word.Length - 1) + word.Substring(0, 1) + "ay";
                    s += word2 + " ";
                }

                s = s.Substring(0, s.Length - 1);
                return s;
            }

            public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
            {

                List<T> list = new List<T>();

                foreach (T element in iterable)
                {
                    if (!list.Contains(element))
                        list.Add(element);
                    else if (list.LastIndexOf(element) != list.Count - 1)
                        list.Add(element);
                }

                return list;

            }

            public static IEnumerable<T> UniqueInOrder2<T>(IEnumerable<T> iterable)
            {
                T previous = default(T);
                foreach (T current in iterable)
                {
                    if (!current.Equals(previous))
                    {
                        previous = current;
                        yield return current;
                    }
                }
            }

            public static IEnumerable<T> UniqueInOrder3<T>(IEnumerable<T> iterable)
            {
                return iterable.Where((x, i) => i == 0 || !Equals(x, iterable.ElementAt(i - 1)));

            }

            public static int[] DeleteNth(int[] arr, int x)
            {
                List<int> list = arr.ToList();

                for (int i = 0; i < list.Count; i++)
                {
                    int sameCount = 0;

                    for (int j = 0; j < list.Count; j++)
                    {

                        if (list[i] == list[j])
                        {
                            sameCount++;

                            if (sameCount > x)
                            {
                                list.RemoveAt(j);
                            }
                        }
                    }
 
                }

                for (int i = 0; i < list.Count; i++)
                {
                    int sameCount = 0;

                    for (int j = 0; j < list.Count; j++)
                    {

                        if (list[i] == list[j])
                        {
                            sameCount++;

                            if (sameCount > x)
                            {
                                list.RemoveAt(j);
                            }
                        }
                    }
                }

                return list.ToArray<int>();
            }

            public static int[] DeleteNth2(int[] arr, int x)
            {
                return arr.Where((t, i) => arr.Take(i + 1).Count(s => s == t) <= x).ToArray();
            }

            public static int[] DeleteNth3(int[] arr, int x)
            {
                var result = new List<int>();
                foreach (var item in arr)
                {
                    if (result.Count(i => i == item) < x)
                        result.Add(item);
                }
                return result.ToArray();
            }
        }
    }
}




