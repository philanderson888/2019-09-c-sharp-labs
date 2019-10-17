using System;
// reference our classes from other project
using lab_48_api_todo_list_core;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace lab_48_read_api
{
    class Program
    {
        static string url = "https://localhost:44315/api/TaskItems/";
        static HttpClient client = new HttpClient();
        static TaskItem taskitem = null;
        static List<TaskItem> taskitems = new List<TaskItem>();
        static void Main(string[] args)
        {
            GetTaskItemsAsync().Wait();
            DisplayTaskItems();
            // get task with fixed id 1
            GetTaskItemAsync(1).Wait();
            DisplayTaskItem();

            var t = new TaskItem
            {
                Description = "New Task",
                TaskDone = false,
                DateDue = DateTime.Parse("12/12/2019"),
                UserId=2,
                CategoryId=3
            };
            TaskItem newitem = PostNewTaskItemAsync(t).Result;
            Console.WriteLine($"New Customer Created with ID {newitem.TaskItemId}");
        }

        static async Task GetTaskItemsAsync()
        {
            Console.WriteLine("Getting Task Items");
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                // RAW JSON STRING
                var responseString =
                    await response.Content.ReadAsStringAsync();
                // use Newtonsoft to deserialise string into LIST OF TASKITEMS
                taskitems =
                    JsonConvert.DeserializeObject<List<TaskItem>>(responseString);
            }
        }

        static async Task GetTaskItemAsync(int taskitemid)
        {
            Console.WriteLine($"Getting Task Item {taskitemid}");
            var response = await client.GetAsync($"{url}{taskitemid}");
            if (response.IsSuccessStatusCode)
            {
                // RAW JSON STRING
                var responseString =
                    await response.Content.ReadAsStringAsync();
                // use Newtonsoft to deserialise string into LIST OF TASKITEMS
                taskitem =
                    JsonConvert.DeserializeObject<TaskItem>(responseString);
            }
        }

        static async Task<TaskItem> PostNewTaskItemAsync(TaskItem t)
        {
            var taskitemstring = JsonConvert.SerializeObject(t);  // AS STRING
            var taskitemhttp = new StringContent(taskitemstring); // AS HTTP REQUEST
            taskitemhttp.Headers.ContentType.MediaType = "application/json";
            taskitemhttp.Headers.ContentType.CharSet = "UTF-8";
            HttpResponseMessage response = await client.PostAsync(url, taskitemhttp);
            // convert response to JSON
            var newitemasjson = response.Content.ReadAsStringAsync();
            // serialise object to <TASKITEM> type
            var newitemastask = 
                JsonConvert.DeserializeObject<TaskItem>(newitemasjson.Result);
            Console.WriteLine(newitemastask.TaskItemId);
            // return <TASKITEM> 
            return newitemastask;
        }




        static void DisplayTaskItems()
        {
            taskitems.ForEach(t => {
                Console.WriteLine($"{t.TaskItemId,-10}{t.Description,-30}{t.TaskDone,-10}" +
                    $"{t.DateDue}");
            });
        }
        static void DisplayTaskItem()
        {
            Console.WriteLine($"{taskitem.TaskItemId,-10}{taskitem.Description,-30}{taskitem.TaskDone,-10}" +
    $"{taskitem.DateDue}");
        }
    }
}
