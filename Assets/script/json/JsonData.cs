namespace script
{
    public class JsonData
    {
        private int _level;
        private float _hp;
        private string _name;

        public JsonData(int level, float hp, string name)
        {
            this._level = level;
            this._hp = hp;
            this._name = name;
        }

        public int Level
        {
            get { return _level; } 
            set { _level = value; }
        }

        public float Hp
        {
            get { return _hp; }
            set { _hp = value; }
        }
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}