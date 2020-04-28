using System;
using System.Collections.Generic;
using System.Linq;

namespace Trello
{
    public class Board
    {
        public List<Task> tasksList;
        public List<User> usersList;
 
        public void CreateTask()
        {

            Console.WriteLine("Input task title:");
            var title = Console.ReadLine();

            Console.WriteLine("Input task description:");
            var descr = Console.ReadLine();
            Console.WriteLine("Input task member:");
            var userName = Console.ReadLine();

            tasksList = new List<Task>
            {

            };
            tasksList.Add(new Task { Title = title, Description = descr, user = new User(userName)}) ;
        }
        public void CreateUser()
        {
            Console.WriteLine("Provide name of user");
            var userName = Console.ReadLine();
            if(!String.IsNullOrWhiteSpace(userName))
            {
                usersList = new List<User>
                {

                };
                usersList.Add(new User(userName));
            }

        }
        public void ShowAllTasks()
        {
            Console.WriteLine("Number |    Title     | Status |    Decsription");

            tasksList.ForEach(t => Console.WriteLine($"{tasksList.IndexOf(t)} |   {t.Title}   | {t.TaskStatus} | {t.Description} "));

        }
        public void ShowAllUsers()
        {
            Console.WriteLine("Number");
            usersList.ForEach(u => Console.WriteLine($"{tasksList.IndexOf(u)}"));
        }
        private void ShowAllStatuses()
        {
            int i = 0;
            foreach (var enumValue in Enum.GetValues(typeof(TaskStatus)))
                Console.WriteLine($"{i++}. {enumValue}");
        }
        public void ChangeTaskStatus()
        {
            ShowAllTasks();

            Console.WriteLine("Input task number:");
            var numberStr = Console.ReadLine();

            int taskNumber;
            if (!int.TryParse(numberStr, out taskNumber))
                Console.WriteLine("Incorrect task number!");

            ShowAllStatuses();

            Console.WriteLine("Input status number:");
            var statusStr = Console.ReadLine();

            int statusNumber;
            if (!int.TryParse(statusStr, out statusNumber))
                Console.WriteLine("Incorrect status number!");

            tasksList[taskNumber].TaskStatus = (TaskStatus)statusNumber;

            ShowAllTasks();

        }

        public void ChangeName()
        {
            ShowAllTasks();

            Console.WriteLine("Input task number:");
            var numberStr = Console.ReadLine();

            int taskNumber;
            if (!int.TryParse(numberStr, out taskNumber))
                Console.WriteLine("Incorrect task number!");

            Console.WriteLine("Input new title for task:");
            var newTitle = Console.ReadLine();

            if(!String.IsNullOrWhiteSpace(newTitle))
            {
                tasksList[taskNumber].Title = new string(newTitle);
            } else
            {
                Console.WriteLine("Please provide new title that is not empty and doen't contain spaces");
            }

            ShowAllTasks();

        }
        public void ChangeDescription()
        {
            ShowAllTasks();

            Console.WriteLine("Input task number:");
            var numberStr = Console.ReadLine();

            int taskNumber;
            if (!int.TryParse(numberStr, out taskNumber))
                Console.WriteLine("Incorrect task number!");

            ShowAllStatuses();

            Console.WriteLine("Input new decription:");
            var newDescription = Console.ReadLine();

            if(!String.IsNullOrWhiteSpace(newDescription)) {
                tasksList[taskNumber].Description = new string(newDescription);
            } else
            {
                Console.WriteLine("Please provide new decription that is not empty and doen't contain spaces");
            }

            ShowAllTasks();
        }
        public void ChangeAssignee()
        {
            ShowAllTasks();

            Console.WriteLine("Input  number:");
            var numberStr = Console.ReadLine();

            int taskNumber;
            if (!int.TryParse(numberStr, out taskNumber))
                Console.WriteLine("Incorrect task number!");

            ShowAllUsers();

            Console.WriteLine("Input user number:");
            var userStr = Console.ReadLine();

            int userNumber;
            if (!int.TryParse(userStr, out userNumber))
                Console.WriteLine("Incorrect user number!");

            tasksList[taskNumber].user = usersList[userNumber];

            ShowAllTasks();
        }

        public void ShowTaskByStatus()
        {
            ShowAllStatuses();

            Console.WriteLine("Input status number:");
            var statusStr = Console.ReadLine();

            int statusNumber;
            if (!int.TryParse(statusStr, out statusNumber))
                Console.WriteLine("Incorrect status number!");

            Console.WriteLine(tasksList.Where(t => t.TaskStatus == (TaskStatus)statusNumber));
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("Menu \n 1. Create task \n 2. Change task status \n 3. Show all tasks \n 4. Change title \n 5. Change description \n 6. Show task of selected status ");

                var key = Console.ReadKey().KeyChar;

                switch (key)
                {
                    case '1':
                        CreateTask();
                        break;

                    case '2':
                        ChangeTaskStatus();
                        break;

                    case '3':
                        ShowAllTasks();
                        break;
                    case '4':
                        ChangeName();
                            break;
                    case '5':
                        ChangeDescription();
                        break;
                    case '6':
                        ShowTaskByStatus();
                        break;

                    default:
                        return;
                }
            }
        }
    }
}