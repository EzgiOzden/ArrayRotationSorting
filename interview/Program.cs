using interview.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace interview
{
    class Program
    {
        public static List<int> SortedElements { get; set; } = new List<int>();
        public static bool IsSorted { get; set; } = true;
        public static List<string> Result { get; set; } = new List<string>();

        static void Main(string[] args)
        {
            bool IsLoadInputValue = true;
            do
            {
                Helper.InputTestCounter = Helper.GetInputData(Helper.MessageInputTestCounter);
                if (Helper.InputTestCounter == 0)
                    IsLoadInputValue = true;
                else
                    IsLoadInputValue = false;
            } while (IsLoadInputValue);

            for (int i = 0; i < Helper.InputTestCounter; i++)
            {
                string consoleResult = null;
                do
                {
                    Helper.InputLoading();

                    var control = SortControl();
                    IsSorted = !control.IsSortedSuccess;
                    consoleResult = control.IsResultTrue ? "YES" : "NO";

                } while (IsSorted);
                Result.Add(consoleResult);
            }

            foreach (var result in Result)
            {
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }

        public static ResponseModel SortControl()
        {
            ResponseModel response;
            SortedElements.Clear();


            if (Helper.InputArray.Count() < 3)
            {
                return response = new ResponseModel()
                {
                    IsResultTrue = false,
                    IsSortedSuccess = true
                };
            }

            for (int i = 0; i < Helper.InputArray.Length; i++)
            {
                if (i + 1 != Helper.InputArray[i])
                {
                    var con = true;
                    do
                    {
                        if (i + 1 == Helper.InputArray[i])
                        {
                            SortedElements.Add(Helper.InputArray[i]);
                            con = false;
                            break;
                        }

                        var orderIndex = Array.IndexOf(Helper.InputArray, i + 1);
                        var rotationElements = GetElementForRotation(orderIndex);

                        if (rotationElements.Count() == 0 || rotationElements == null)
                        {
                            return response = new ResponseModel()
                            {
                                IsResultTrue = false,
                                IsSortedSuccess = true
                            };
                        }

                        Helper.InputArray = Rotation(Helper.InputArray, rotationElements[0], rotationElements[1], rotationElements[2]);

                    } while (con);


                }
                else
                {
                    SortedElements.Add(Helper.InputArray[i]);
                }
            }

            for (int i = 0; i < SortedElements.ToArray().Length; i++)
            {
                if (SortedElements[i] != i + 1)
                {
                    return response = new ResponseModel()
                    {
                        IsResultTrue = false,
                        IsSortedSuccess = true
                    };
                }
            }

            if (SortedElements.Count() != Helper.InputArray.Length)
            {
                return response = new ResponseModel()
                {
                    IsResultTrue = false,
                    IsSortedSuccess = true
                };
            }

            return response = new ResponseModel()
            {
                IsResultTrue = true,
                IsSortedSuccess = true
            };
        }

        public static int[] GetElementForRotation(int orderIndex)
        {
            List<int> rotationElements = new List<int>();

            try
            {
                if (!SortedElements.Contains(Helper.InputArray[orderIndex - 1]) && !SortedElements.Contains(Helper.InputArray[orderIndex - 2]))
                {
                    rotationElements.Add(Helper.InputArray[orderIndex - 2]);
                    rotationElements.Add(Helper.InputArray[orderIndex - 1]);
                    rotationElements.Add(Helper.InputArray[orderIndex]);

                    return rotationElements.ToArray();
                }

                else if (!SortedElements.Contains(Helper.InputArray[orderIndex - 1]) && !SortedElements.Contains(Helper.InputArray[orderIndex + 1]))
                {
                    rotationElements.Add(Helper.InputArray[orderIndex - 1]);
                    rotationElements.Add(Helper.InputArray[orderIndex]);
                    rotationElements.Add(Helper.InputArray[orderIndex + 1]);

                    return rotationElements.ToArray();
                }

                else if (!SortedElements.Contains(Helper.InputArray[orderIndex]) && SortedElements.Contains(Helper.InputArray[orderIndex - 2]) || SortedElements.Contains(Helper.InputArray[orderIndex - 1]))
                {
                    return rotationElements.ToArray();
                }

                return rotationElements.ToArray();
            }
            catch (Exception)
            {
                if (Helper.InputArray.Count() - SortedElements.Count() < 3)
                {
                    return rotationElements.ToArray(); 
                }

                if (orderIndex + 1 <= Helper.InputArray.Length)
                {
                    rotationElements.Add(Helper.InputArray[orderIndex - 1]);
                    rotationElements.Add(Helper.InputArray[orderIndex]);
                    rotationElements.Add(Helper.InputArray[orderIndex + 1]);

                    return rotationElements.ToArray();
                }
                else
                {
                    return rotationElements.ToArray();
                }
            }
        }

        public static int[] Rotation(int[] ABCArray, int A, int B, int C)
        {
            int AValue = ABCArray.FirstOrDefault(p => p == A);
            int AIndex = Array.IndexOf(ABCArray, A);

            int BValue = ABCArray.FirstOrDefault(p => p == B);
            int BIndex = Array.IndexOf(ABCArray, B);

            int CValue = ABCArray.FirstOrDefault(p => p == C);
            int CIndex = Array.IndexOf(ABCArray, C);

            ABCArray[AIndex] = BValue;
            ABCArray[BIndex] = CValue;
            ABCArray[CIndex] = AValue;

            return ABCArray;
        }
    }

    public class ResponseModel
    {
        public bool IsSortedSuccess { get; set; }
        public bool IsResultTrue { get; set; }
    }
}
