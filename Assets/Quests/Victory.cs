internal class Victory : Quest {
    private readonly string leftText;
    private readonly string rightText;

    public Victory(string leftText, string rightText) {
        this.leftText = leftText;
        this.rightText = rightText;
    }

    public Option Left() {
        return new Option(rightText, new Victory(rightText, leftText));
    }

    public Option Right() {
        return new Option(rightText, new Victory(rightText, leftText));
    }

    public string Text() {
        return "Congratulations! Thanks for playing!";
    }
}