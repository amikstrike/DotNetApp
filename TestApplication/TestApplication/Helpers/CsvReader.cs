using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace TestApplication.Helpers
{
    public class CsvReader
    {
        private int _offset;
        private string _path;

        public string TableName;
        public List<List<string>> Rows;
        public List<string> Header;

        public bool SchemaIsValid;


        public CsvReader(string path)
        {
            _offset = 0;
            SchemaIsValid = true;
            Rows = new List<List<string>>();
            Header = new List<string>();
            _path = path;
            TableName = Path.GetFileNameWithoutExtension(_path);
            ReadCsv();
        }

        public void ReadCsv()
        {
            _path = "D:\\Projects\\Ivchenko_Oleg_Test_Application\\TestApplication\\TestApplication\\Resources\\UpTypes.csv";
            string[] rows = File.ReadAllLines(_path);
            Header = rows[0].Split(';').ToList();
            for (int i = 1; i < rows.Length; i++)
            {
                var row = rows[i].Split(';').ToList();
                if (Header.Count != row.Count)
                {
                    SchemaIsValid = false;
                }
                Rows.Add(row);
            }
        }

        public List<string> GetNextRow()
        {
            if (_offset < Rows.Count)
            {
                List<string> nextRow = Rows[_offset];
                _offset++;
                return nextRow;
                
            }
            return null;
        }

        public void ClearOffset()
        {
            _offset = 0;
        }
    }
}