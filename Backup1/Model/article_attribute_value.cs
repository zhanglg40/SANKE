using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    [Serializable]
    public partial class article_attribute_value
    {
        private int _id;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private decimal price;

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        private int num;

        public int Num
        {
            get { return num; }
            set { num = value; }
        }

    }
}
