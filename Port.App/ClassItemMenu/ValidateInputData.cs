using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Port.App.ClassItemMenu
{
    public static class ValidateInputData
    {
        public static int InputId()
        {
            var id = 0;
            var isId = false;
            while (!isId)
            {
                isId = Int32.TryParse(Console.ReadLine(), out id);
                isId = isId && (id > 0);
                if (!isId)
                    Console.WriteLine("Incorrect data!");
            }
            return id;
        }
        public static int InputNumber()
        {
            var number = 0;
            var isNumber = false;
            while (!isNumber)
            {
                isNumber = Int32.TryParse(Console.ReadLine(), out number);
                isNumber = isNumber && (number > 0);
                if (!isNumber)
                    Console.WriteLine("Incorrect data!");
            }
            return number;
        }
        public static string InputName()
        {
            var name = String.Empty;
            var pattern = @"\w";
            var regex = new Regex(pattern);
            var isWrongName = true;
            while (isWrongName)
            {
                name = Console.ReadLine();
                isWrongName = !regex.IsMatch(name, 0);
                if (isWrongName)
                    Console.WriteLine("Incorrect data!");
            }
            return name;
        }

        internal static string InputDate()
        {
            var date = String.Empty;
            var isWrongDate = true;
            while (isWrongDate)
            {
                var dateTime = new DateTime();
                date = Console.ReadLine();
                isWrongDate = !DateTime.TryParse(date, out dateTime);
                if (isWrongDate)
                    Console.WriteLine("Incorrect data!");
                date = dateTime.ToShortDateString();
            }
            return date;
        }
    }
}
