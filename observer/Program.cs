using System;
using System.Collections.Generic;

interface Subject
{
    void registerObserver(Observer observer);
    void removeObserver(Observer observer);
    void notifyObservers();
}

interface Observer
{
    void update(string news);
}

class NewsAgency : Subject
{
    private List<Observer> observers = new List<Observer>();
    private string news;

    public void registerObserver(Observer observer)
    {
        observers.Add(observer);
    }

    public void removeObserver(Observer observer)
    {
        observers.Remove(observer);
    }

    public void notifyObservers()
    {
        foreach (Observer observer in observers)
        {
            observer.update(news);
        }
    }

    public void setNews(string news)
    {
        this.news = news;
        notifyObservers();
    }
}

class NewsChannel : Observer
{
    private string name;
    public NewsChannel(string name)
    {
        this.name = name;
    }
    public void update(string news)
    {
        Console.WriteLine(name + " received news: " + news);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        NewsAgency agency = new NewsAgency();

        NewsChannel channel1 = new NewsChannel("Channel 1");
        NewsChannel channel2 = new NewsChannel("Channel 2");

        agency.registerObserver(channel1);
        agency.registerObserver(channel2);

        agency.setNews("Breaking news: Observer Pattern in action");

        agency.removeObserver(channel2);

        agency.setNews("Another update");
    }
}
