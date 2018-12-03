using System;

public class Option {
    private string text;
    private Action<Player> action;
    private Quest next;

    public Option(string text, Action<Player> action, Quest quest = null) {
        this.text = text;
        this.action = action;
        this.next = quest;
    }

    public string Text() {
        return text;
    }

    public void DoAction(Player player) {
        action(player);
    }

    public Quest Next() {
        return next;
    }
}