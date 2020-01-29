using System;
using System.Linq;

namespace interview.Helpers
{
    public static class Helper
    {
        public static string MessageInputTestCounter { get; set; } = "Input Test Case Counter: ";
        public static string MessageInputArrayLength { get; set; } = "Input Array Length: ";

        public static int InputTestCounter { get; set; } = 0;
        public static int InputArrayLength { get; set; } = 0;
        public static int[] InputArray { get; set; } = new int[0];


        public static void InputLoading()
        {
            bool IsLoadInputValue = true;
            //TODO: connection two do while operation
            do
            {
                InputArrayLength = GetInputData(MessageInputArrayLength);
                if (InputArrayLength == 0)
                    IsLoadInputValue = true;
                else
                    IsLoadInputValue = false;
            } while (IsLoadInputValue);

            do
            {
                var IsArrayLoading = GetArrayValues();
                if (IsArrayLoading)
                {
                    IsLoadInputValue = true;
                }
                else
                {
                    IsLoadInputValue = false;
                }
            } while (IsLoadInputValue);


        }

        public static int GetInputData(string message, int callBackInput = 0)
        {
            Console.Write(message);

            if (callBackInput != 0)
            {
                Console.Write(callBackInput.ToString());
                return callBackInput;
            }

            var CasesInput = int.TryParse(Console.ReadLine(), out callBackInput);
            if (!CasesInput)
                return 0;

            return callBackInput;
        }

        private static bool GetArrayValues()
        {
            int[] _inputArray = new int[InputArrayLength];

            Console.Write("Array Giriniz: ");
            string readLine = Console.ReadLine();
            string[] stringArray = readLine.Split(' ');

            if (stringArray.Length != InputArrayLength)
            {
                Console.WriteLine("Array boyutundan farklı girdiniz tekrar deneyin.");
                return true;
            }

            for (int i = 0; i < stringArray.Length; i++)
            {
                var controlElement = int.TryParse(stringArray[i], out _inputArray[i]);
                if (!controlElement)
                {
                    return true;
                }
            }

            var checkSequence = ControlArrayElement(_inputArray);
            if (!checkSequence)
            {
                Console.WriteLine("Ardışık sayılar giriniz.");
                return true;
            }

            InputArray = _inputArray;

            return false;
        }

        private static bool ControlArrayElement(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                if (!inputArray.Contains(i + 1))
                {
                    return false;
                }

            }
            return true;
        }
    }
}
