using System;

public class Option {
    private string text;
    private Action action;
    private Quest next;

    public Option(string text, Quest quest = null) : this(text, () => { }, quest) { }

    public Option(string text, Action action, Quest quest = null) {
        this.text = text;
        this.action = action;
        this.next = quest;
    }

    public string Text() {
        return text;
    }

    public void DoAction() {
        action();
    }

    public Quest Next() {
        return next;
    }
}