using System.Text;
using IFramework.Serialization.DataTable;

namespace EMO.ServerCore.Modules.Config
{
    public abstract class Config<TData> : IConfig
    {
        protected List<TData> datas = new List<TData>();
        protected abstract string path { get; } 
        protected Config() { Read(); }
        private void Read()
        {
            if (!File.Exists(path))
            {
                Write(new List<TData>());
            }
            var result = File.ReadAllText(path, Encoding.UTF8);
            datas = DeSerializatie(result);
        }

        public void Write(List<TData> data)
        {
            if (data == null) return;
            var str = Serializatie(data);
            File.WriteAllText(path, str, Encoding.UTF8);
        }
        protected virtual string Serializatie(List<TData> data)
        {
            var w = DataTableTool.CreateWriter(new StreamWriter(path, false),
                new DataRow(),
                new DataExplainer());
            var str = w.WriteString(data);
            w.Dispose();
            return str;
        }
        protected virtual List<TData> DeSerializatie(string data)
        {
            var r =
               DataTableTool.CreateReader(data,
               new DataRow(),
               new DataExplainer());
            datas = r.Get<TData>();
            r.Dispose();
            return datas;
        }


        public void SaveChanges()
        {
            Write(this.datas);
        }
    }
}
