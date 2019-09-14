public class Brujin
{

    private static int[] sequence =
    {
        0, 1, 28, 2, 29, 14, 24, 3, 30, 22, 20, 15, 25, 17, 4, 8,
        31, 27, 13, 23, 21, 19, 16, 7, 26, 12, 18, 6, 11, 5, 10, 9
    };

    public static int Position(int number)
    {
        uint res = unchecked((uint)(number & -number) * 0x77CB531U) >> 27;
        return sequence[res];
    }

}