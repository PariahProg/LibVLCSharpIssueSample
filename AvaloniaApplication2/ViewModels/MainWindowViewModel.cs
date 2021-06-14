using System;
using AvaloniaApplication2.Models;
using ReactiveUI;
using System.Reactive;
using System.Collections.ObjectModel;
using LibVLCSharp.Shared;

namespace AvaloniaApplication2.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IDisposable
    {
        private readonly LibVLC libVLC = new LibVLC();
        public MediaPlayer MediaPlayer { get; }
        private Book book;
        private ObservableCollection<Item> currentItems;
        public Book Book
        {
            get
            {
                return book;
            }
            set
            {
                book = value;
            }
        }
        public ObservableCollection<Item> CurrentItems
        {
            get => currentItems;
            set => this.RaiseAndSetIfChanged(ref currentItems, value);
        }

        public ReactiveCommand<string, Unit> PlayVideoCommand { get; }
        public MainWindowViewModel()
        {
            book = new Book();

            PlayVideoCommand = ReactiveCommand.Create<string>(DoPlayVideo);

            book.Items.Add(new TextItem("TextItem", "Content of text item"));
            book.Items.Add(new VideoItem("videoNItem", "\\Assets\\Waterfall.mp4"));
            CurrentItems = book.Items;
            MediaPlayer = new MediaPlayer(libVLC);
        }
        private void DoPlayVideo(string path)
        {
            // provide an absolute path to Assets\Waterfall.MP4
            using var media = new Media(libVLC, new Uri(System.IO.Directory.GetCurrentDirectory() + @"\..\..\..\" + path));
            MediaPlayer.Play(media);
        }

        public void Dispose()
        {
            MediaPlayer?.Dispose();
            libVLC?.Dispose();
        }
    }
}
