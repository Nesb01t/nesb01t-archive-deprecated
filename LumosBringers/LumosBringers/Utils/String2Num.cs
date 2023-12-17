namespace LumosBringers.Utils;

public class String2Num
{
    public static float GetFloat(string str)
    {
        float f;
        bool success = float.TryParse(str, out f);
        if (success)
        {
            return f;
        }
        else
        {
            return 0.0f;
        }
    }
}