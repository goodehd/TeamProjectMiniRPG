using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Managers
{
    public class TestData : IGameData<int>
    {
        public int Key { get; set; }
        public string Name;
        public string Type;
        public int Attack;
        public string Description;
    }

    public class DataManager
    {
        public Dictionary<int, TestData> _datas { get; private set; }

        public void Init()
        {
            CsvToJson("testData");
            _datas = LoadData<List<TestData>>("testData").ToDictionary<int, TestData>();

            TestData test1 = new TestData();

            test1.Key = 2;
            test1.Name = "test";
            test1.Type = "type";
            test1.Attack = 1;
            test1.Description = "description";

            SaveData<TestData>(test1, "testData2");
            TestData test2 = LoadData<TestData>("testData2");
        }

        // memory -> json
        public void SaveData<T>(T obj, string fileName, string path = Literals.JSON_PATH)
        {
            string jsonSting = JsonConvert.SerializeObject(obj, Formatting.Indented);
            File.WriteAllText($"{path}{fileName}.json", jsonSting);
        }

        // json -> memory
        public T LoadData<T>(string fileName, string path = Literals.JSON_PATH)
        {
            string fullPath = $"{path}{fileName}.json";

            if (!FindFile(fullPath))
                return default(T);

            string jsonData = File.ReadAllText($"{path}{fileName}.json");
            T loadData = JsonConvert.DeserializeObject<T>(jsonData);
            return loadData;
        }

        //csv -> json
        public void CsvToJson(string fileName, string path = Literals.CSV_PATH)
        {
            string fullPath = $"{path}{fileName}.csv";

            if (!FindFile(fullPath))
                return;

            string[] csvLines = File.ReadAllLines(fullPath);

            List<Dictionary<string, object>> dataList = new List<Dictionary<string, object>>();
            string[] headers = csvLines[0].Split(',');
            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] values = csvLines[i].Split(',');
                Dictionary<string, object> dataEntry = new Dictionary<string, object>();

                for (int j = 0; j < headers.Length && j < values.Length; j++)
                {
                    dataEntry[headers[j]] = values[j];
                }

                dataList.Add(dataEntry);
            }

            string jsonSting = JsonConvert.SerializeObject(dataList, Formatting.Indented);
            File.WriteAllText($"{Literals.JSON_PATH}{fileName}.json", jsonSting);
        }

        private bool FindFile(string path)
        {
            if (File.Exists(path))
                return true;

            Debug.Log($"File not found, Path : {path}");
            return false;
        }
    }
}