public class ViewCountActiv : View
{
    private void OnEnable()
    {
        _generator.ChangeCountActive += ChangeText;
    }

    private void OnDisable()
    {
        _generator.ChangeCountActive -= ChangeText;
    }
}
