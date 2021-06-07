using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace litecart
{
    public class ZoneData : IEquatable<ZoneData>, IComparable<ZoneData>
    {
        public string name;

        public ZoneData(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public bool Equals(ZoneData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name; //the same as expression "return Name.Equals(other.Name)"
        }

        public override string ToString()
        {
            return "name=" + Name;
        }

        public int CompareTo(ZoneData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
    }
}
