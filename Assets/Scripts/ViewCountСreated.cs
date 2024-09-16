public class ViewCount—reated : View
{
    private void OnEnable()
    {
        _generator.ChangeCountCreat += ChangeText;
    }

    private void OnDisable()
    {
        _generator.ChangeCountCreat -= ChangeText;
    }
}