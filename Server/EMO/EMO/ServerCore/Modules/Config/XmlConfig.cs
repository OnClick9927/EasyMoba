using System.Text;
using IFramework.Serialization;

namespace EMO.ServerCore.Modules.Config
{
    public abstract class XmlConfig<TData> : IConfig where TData : new()
    {
        private TData _data;
        public TData data => _data;
        protected abstract string path { get; } 
        protected XmlConfig() { Read(); }
        private void Read()
        {
            if (!File.Exists(path))
            {
                Write(new TData());
            }
            var result = File.ReadAllText(path, Encoding.UTF8);
            _data = DeSerializatie(result);
        }

        public void Write(TData data)
        {
            if (data == null) return;
            var str = Serializatie(data);
            File.WriteAllText(path, str, Encoding.UTF8);
        }
        protected virtual string Serializatie(TData data)
        {
            return Xml.ToXml(data);
        }
        protected virtual TData DeSerializatie(string data)
        {
            return Xml.FromXml<TData>(data);
        }


        public void SaveChanges()
        {
            Write(this._data);
        }
    }
}
