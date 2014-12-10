﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Library.App.Menu;
using Port.App.ClassItemMenu;

namespace Port.App
{
    class InteractiveConsole
    {
        public InteractiveConsole()
        {
            _pathCurrentMenu = "MainMenu";
            _numberItemMenu = 0;
            _operation = String.Empty;
            _navigationMenu = new Dictionary<ConsoleKey, Action>
            {
                { ConsoleKey.DownArrow, this.DownCursor},
                { ConsoleKey.UpArrow, this.UpCursor},
                { ConsoleKey.Enter, this.EnterMenuItem},
                { ConsoleKey.Escape, this.EscapeMenu},
            };
        }
        #region Variables
        // функции для навигации по меню
        readonly Dictionary<ConsoleKey, Action> _navigationMenu;
        //
        private ItemMenu _itemMenu;
        // верхний левый угол меню  
        const int LEFT = 7;
        const int TOP = 3;
        // текущая место положение
        string _pathCurrentMenu;
        // текущая операция
        string _operation;
        // имя файла, где хранится footer
        const string _footerOperation = "Press Enter to repeat operation, Esc- exit";
        const string _footerMenu = "Press Enter to skip, Esc - exit";
        // меню
        string _menu;
        // номер выбраного элемента меню
        int _numberItemMenu;
        // объект курсора
        Cursor cursor = Cursor.Create();
        // введеный символ
        ConsoleKey choose;
        #endregion
        /// <summary>
        /// Запуск консоли
        /// </summary>
        public void Process()
        {
            // загрузка каталога
            while (true)
            {
                Console.Clear();
                Console.CursorVisible = false;
                // вывод пути
                PrintLocation();
                bool performOperation;
                if (_itemMenu != null)
                {
                    performOperation = _itemMenu.OperationItemMenu.ContainsKey(_operation) && choose == ConsoleKey.Enter;
                }
                else
                {
                    performOperation = false;
                }
                if (performOperation)
                    PerformOperation();
                else
                {
                    _menu = PrintMainMenu();
                    if(_pathCurrentMenu.IndexOf(".") == -1)
                        _itemMenu = FactoryItemsMenu.CreateItemMenu(_numberItemMenu);
                }
                PrintFooter(performOperation);
                PrintCursor(_menu);
                choose = Console.ReadKey(true).Key;
               
                try
                {
                    _navigationMenu[choose]();
                }
                catch (KeyNotFoundException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        // Отрисовка курсора
        private void PrintCursor(string menu)
        {
            // определяем к-во строк в меню
            int maxNumberOfItemMenu = new Regex("\n").Matches(menu).Count - 1;
            if (maxNumberOfItemMenu == -1)
            {
                return;
            }
            if (_numberItemMenu < 0)
                _numberItemMenu = 0;
            _numberItemMenu = Math.Max(0, _numberItemMenu);
            _numberItemMenu = Math.Min(maxNumberOfItemMenu, _numberItemMenu);
            // рисуем курсор в указаной позиции
            cursor.SetCursor(TOP + _numberItemMenu, LEFT);
            cursor.Print();
        }

        // Выполнение операции
        private void PerformOperation()
        {
                Console.CursorVisible = true;
                cursor.visible = false;
                _itemMenu.OperationItemMenu[_operation]();
                Console.CursorVisible = false;
        }
        // Вывод меню
        string PrintMainMenu()
        {
            cursor.visible = true;
            // поместим сюда меню
            var _sbmenu = new StringBuilder();
            // ищем файл с заданным именем
            string path = PathFolder(_pathCurrentMenu);
            if (!File.Exists(path))
            {
                Console.WriteLine("Don't find file");
                EscapeMenu();
            }
            else
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    //start position for menu
                    cursor.SetCursor(TOP, LEFT);
                    while (!sr.EndOfStream)
                    {
                        string buffer = sr.ReadLine();
                        _sbmenu.AppendLine(buffer);
                        cursor.SetCursor(cursor.top, LEFT);
                        Console.WriteLine(buffer);
                        cursor.top++;
                    }
                }
            }
            return _sbmenu.ToString();
        }
        // получения пути к файлу
        string PathFolder(string currentFolder)
        {
            int indexPoint = currentFolder.LastIndexOf(".");
            string PathToBinDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            return Directory.GetParent(PathToBinDirectory) + "\\Menu\\" + currentFolder.Substring(indexPoint + 1, currentFolder.Length - indexPoint - 1) + ".txt";  
        }
        void PrintFooter(bool performOperation)
        {
            int height = Math.Max(Console.CursorTop,Console.WindowHeight - 1);
            cursor.SetCursor(height, 0);
            if (performOperation)
                Console.Write(_footerOperation);
            else
                Console.Write(_footerMenu);
        }
        void PrintLocation()
        {
            //position Path
            cursor.SetCursor(0, 2);
            Console.WriteLine(_pathCurrentMenu);
        }
        // переместить курсор вниз
        void DownCursor()
        {
            if (cursor.visible)
                _numberItemMenu++;
        }
        // вверх
        void UpCursor()
        {
            if (cursor.visible)
                _numberItemMenu--;
        }

        //выбрать пункт меню
        void EnterMenuItem()
        {
            if (cursor.visible)
            {
                string nextMenu;
                try
                {
                    nextMenu = _menu.Split('\n')[cursor.top - TOP];
                }
                catch(IndexOutOfRangeException)
                {
                    return;
                }
                nextMenu = nextMenu.TrimEnd('\r');
                string pathNextMenu = _pathCurrentMenu + "." + nextMenu;
                if (!File.Exists(PathFolder(pathNextMenu)))
                    _menu = String.Empty;
                _pathCurrentMenu = pathNextMenu;
                _operation = nextMenu;
                _numberItemMenu = 0;
            }
        }
        // вернуться в передыдущее меню
        void EscapeMenu()
        {
            int indexPoint = _pathCurrentMenu.IndexOf(".");
            if (indexPoint == -1)
                Exit();
            _pathCurrentMenu = _pathCurrentMenu.Remove(indexPoint, _pathCurrentMenu.Length - indexPoint);
        }

        void Exit()
        {
            Console.Clear();
            Environment.Exit(0);
        }
      
    }
}
