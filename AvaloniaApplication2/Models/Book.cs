using System.Collections.ObjectModel;

namespace AvaloniaApplication2.Models
{
    public abstract class Item
    {
        public string Name { get; set; }

        public Item(string name)
        {
            Name = name;
        }
    }

    public class TextItem : Item
    {
        public string Text { get; set; }

        public TextItem(string name, string content)
            : base(name)
        {
            Text = content;
        }
    }

    public class ImageItem : Item
    {
        public string RelativePath { get; set; }

        public ImageItem(string name, string relativePath)
            : base(name)
        {
            RelativePath = relativePath;
        }
    }

    public class VideoItem : Item
    {
        public string RelativePath { get; set; }
        public VideoItem(string name, string relativePath)
            : base(name)
        {
            RelativePath = relativePath;
        }
    }
    public class Book
    {
        public ObservableCollection<Item> Items { get; set; }

        public Book()
        {
            Items = new ObservableCollection<Item>();
        }
    }
}
