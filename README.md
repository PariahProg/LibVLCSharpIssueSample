# LibVLCSharpIssueSample
1) My model is "Book" with IObservable<Item> collection of different page content like text, image, video.
2) In view I have an ItemsControl bound to CurrentItems (which is similar to  IObservable<Item> collection but with RaiseAndSetIfChanged) with diffrerent data templates.
3) In viewmodel I initialize my collection with 2 different contents: text and video. When runnin program, text is displayed correctly, but video is displayed in new window.
I checked binding for MediaPlayer. It seems to be correct now.
