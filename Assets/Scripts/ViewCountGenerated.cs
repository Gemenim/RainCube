public class ViewCountGenerated : View
{
    private void OnEnable()
    {
        _generator.ChangeCount += ChangeText;
    }

    private void OnDisable()
    {
        _generator.ChangeCount -= ChangeText;
    }
}
