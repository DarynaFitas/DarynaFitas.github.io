//варіант 11
//Інтегратор пошуку пісень на різних платформах: Запит користувача містить жанр та платформу, повернути список назв пісень згідно із запитом.
//А) аpi Spotify приймає запит, що містить список жанрів і повертає всі пісні вказаних жанрів.
//Б) api Apple Music завжди повертає список всіх Пісень (назва, список жанрів) незалежно від запиту
//В) При запитах до YouTube music чи інших сервісів вивести повідомлення про відсутність співпраці.

using System;
using System.Collections.Generic;

public interface IMusicSearchStrategy
{
    List<string> SearchSongs(string genre);
}

public class SpotifyMusicSearchStrategy : IMusicSearchStrategy
{
    public List<string> SearchSongs(string genre)
    {
        List<string> songs = new List<string>();
        songs.Add("Поп");
        songs.Add("Рок");
        songs.Add("Реп");
        songs.Add("Панк рок");
        songs.Add("Альтернатива");
        return songs;
    }
}

public class YouTubeMusicSearchStrategy : IMusicSearchStrategy
{
    public List<string> SearchSongs(string genre)
    {

        List<string> songs = new List<string>();

        if (!IsSupportedPlatform("YouTubeMusic"))
        {
            Console.WriteLine("Пошук на YouTube Music не підтримується.");
            return songs;
        }


        return songs;
    }

    private bool IsSupportedPlatform(string platform)
    {
        return platform == "YouTubeMusic";
    }
}


public class AppleMusicSearchStrategy : IMusicSearchStrategy
{
    public List<string> SearchSongs(string genre)
    {
        List<string> songs = new List<string>();
        songs.Add("4 miniuted");
        songs.Add("Talk");
        songs.Add("Maneater");
        songs.Add("Flawless");
        songs.Add("Promiscuos");
        return songs;
    }
}

public class MusicSearchIntegrator
{
    private IMusicSearchStrategy musicSearchStrategy;

    public MusicSearchIntegrator(IMusicSearchStrategy strategy)
    {
        musicSearchStrategy = strategy;
    }

    public List<string> SearchSongs(string genre)
    {
        return musicSearchStrategy.SearchSongs(genre);
    }
}

public class Program
{
    public static void Main()
    {
        IMusicSearchStrategy strategy = ChooseSearchStrategy("Spotify");

        MusicSearchIntegrator musicSearchIntegrator = new MusicSearchIntegrator(strategy);
        List<string> songs = musicSearchIntegrator.SearchSongs("Поп");

        foreach (string song in songs)
        {
            Console.WriteLine(song);
        }
    }

    public static IMusicSearchStrategy ChooseSearchStrategy(string platform)
    {
        if (platform == "Spotify")
        {
            return new SpotifyMusicSearchStrategy();
        }
        else if (platform == "YouTubeMusic")
        {
            return new YouTubeMusicSearchStrategy();
        }
        else if (platform == "AppleMusic")
        {
            return new AppleMusicSearchStrategy();
        }
        else
        {
            Console.WriteLine("Вибрана платформа не підтримується.");
            return null;
        }
    }
}
