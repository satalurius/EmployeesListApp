﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesListApp.Models;

namespace EmployeesListApp
{
    public static class Data
    {
        public static ObservableCollection<Employee> Employees { get; set; }

        static Data()
        {
            Employees = new ObservableCollection<Employee>
            {
                new()
                {
                    Surname = "Черенков",
                    Name = "Максим",
                    Patronymic = "Алексеевич",
                    Description = "Описание",
                    FullName = $"Черенков Максим Алексеевич",
                    PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/9/9c/Tonkin_snub-nosed_monkeys_%28Rhinopithecus_avunculus%29.jpg/320px-Tonkin_snub-nosed_monkeys_%28Rhinopithecus_avunculus%29.jpg"
                },

                new()
                {
                    Surname = "Черенков",
                    Name = "Не максим",
                    Patronymic = "Алексеевич",
                    FullName = "Черенков Максим Алексеевич",
                    Description = "Описание",
                    PhotoUrl = "url"
                },
            };
        }
    }
}
