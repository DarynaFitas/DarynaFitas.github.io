//Дано колекцію повідомлень (дата, відправник, отримувач, текст). Реалізувати клас надсилання відповіді всім відправникам на повідомлення із заданим текстом. Надіслати відповідь у порядку дати надходження, а також за відправниками (Спочатку на всі повідомлення відправника А, потім відправника Б,...).

using System;
using System.Collections.Generic;
using System.Linq;

class Message
{
    public DateTime Date { get; set; }
    public string Sender { get; set; }
    public string Receiver { get; set; }
    public string Text { get; set; }
}

interface IResponseStrategy
{
    void Respond(List<Message> messages, string replyText);
}

class RespondByDateAndSender : IResponseStrategy
{
    public void Respond(List<Message> messages, string replyText)
    {
        var sortedMessages = messages.OrderBy(m => m.Date).ThenBy(m => m.Sender);
        foreach (var message in sortedMessages)
        {
            Console.WriteLine($"Відправляється повідомлення від {message.Sender} до {message.Receiver}: \"{replyText}\"");
        }
    }
}

class MessageResponder
{
    private IResponseStrategy responseStrategy;

    public MessageResponder(IResponseStrategy strategy)
    {
        responseStrategy = strategy;
    }

    public void SetResponseStrategy(IResponseStrategy strategy)
    {
        responseStrategy = strategy;
    }

    public void RespondToMessages(List<Message> messages, string replyText)
    {
        responseStrategy.Respond(messages, replyText);
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Message> messages = new List<Message>
        {
            new Message { Date = DateTime.Now, Sender = "Естер", Receiver = "Ангеліна", Text = "Привіт!" },
            new Message { Date = DateTime.Now, Sender = "Борис", Receiver = "Іван", Text = "Давай зустрінемося на вихідних" },
            new Message { Date = DateTime.Now, Sender = "Аліна", Receiver = "Артем", Text = "Купи хліб та молоко" }
        };

        MessageResponder responder = new MessageResponder(new RespondByDateAndSender());
        responder.RespondToMessages(messages, "Відповідь на ваше повідомлення");
    }
}
